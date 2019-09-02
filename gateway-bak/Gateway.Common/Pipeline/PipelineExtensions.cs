using Gateway.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Common.Pipeline
{
    public static class PipelineExtensions
    {
        internal const string InvokeMethodName = "Invoke";
        internal const string InvokeAsyncMethodName = "InvokeAsync";

        private static readonly MethodInfo GetServiceInfo = typeof(PipelineExtensions).GetMethod(nameof(GetService), BindingFlags.NonPublic | BindingFlags.Static);

        public static IPipelineBuilder UseMiddleware<TMiddleware>(this IPipelineBuilder app, params object[] args)
        {
            return app.UseMiddleware(typeof(TMiddleware), args);
        }

        public static IPipelineBuilder UseMiddleware(this IPipelineBuilder app, Type middleware, params object[] args)
        {
            return app.Use(next =>
            {
                var methods = middleware.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                var invokeMethods = methods.Where(m =>
                    string.Equals(m.Name, InvokeMethodName, StringComparison.Ordinal)
                    || string.Equals(m.Name, InvokeAsyncMethodName, StringComparison.Ordinal)
                ).ToArray();

                if (invokeMethods.Length > 1)
                {
                    throw new InvalidOperationException();
                }

                if (invokeMethods.Length == 0)
                {
                    throw new InvalidOperationException();
                }

                var methodinfo = invokeMethods[0];
                if (!typeof(Task).IsAssignableFrom(methodinfo.ReturnType))
                {
                    throw new InvalidOperationException();
                }

                var parameters = methodinfo.GetParameters();
                if (parameters.Length == 0 || parameters[0].ParameterType != typeof(RouteContext))
                {
                    throw new InvalidOperationException();
                }

                var ctorArgs = new object[args.Length + 1];
                ctorArgs[0] = next;
                Array.Copy(args, 0, ctorArgs, 1, args.Length);
                var instance = ActivatorUtilities.CreateInstance(app.ApplicationServices, middleware, ctorArgs);
                if (parameters.Length == 1)
                {
                    var ocelotDelegate = (CustomRequestDelegate)methodinfo.CreateDelegate(typeof(CustomRequestDelegate), instance);
                    var diagnosticListener = (DiagnosticListener)app.ApplicationServices.GetService(typeof(DiagnosticListener));
                    var middlewareName = ocelotDelegate.Target.GetType().Name;

                    CustomRequestDelegate wrapped = context =>
                    {
                        try
                        {
                            Write(diagnosticListener, "Ocelot.MiddlewareStarted", middlewareName, context);
                            return ocelotDelegate(context);
                        }
                        catch (Exception ex)
                        {
                            WriteException(diagnosticListener, ex, "Ocelot.MiddlewareException", middlewareName, context);
                            throw ex;
                        }
                        finally
                        {
                            Write(diagnosticListener, "Ocelot.MiddlewareFinished", middlewareName, context);
                        }
                    };

                    return wrapped;
                }

                var factory = Compile<object>(methodinfo, parameters);

                return context =>
                {
                    var serviceProvider = context.HttpContext.RequestServices ?? app.ApplicationServices;
                    if (serviceProvider == null)
                    {
                        throw new InvalidOperationException();
                    }

                    return factory(instance, context, serviceProvider);
                };
            });
        }


        private static void Write(DiagnosticListener diagnosticListener, string message, string middlewareName, RouteContext context)
        {
            if (diagnosticListener != null)
            {
                diagnosticListener.Write(message, new { name = middlewareName, context = context });
            }
        }

        private static void WriteException(DiagnosticListener diagnosticListener, Exception exception, string message, string middlewareName, RouteContext context)
        {
            if (diagnosticListener != null)
            {
                diagnosticListener.Write(message, new { name = middlewareName, context = context, exception = exception });
            }
        }

        private static Func<T, RouteContext, IServiceProvider, Task> Compile<T>(MethodInfo methodinfo, ParameterInfo[] parameters)
        {
            var middleware = typeof(T);
            var httpContextArg = Expression.Parameter(typeof(RouteContext), "downstreamContext");
            var providerArg = Expression.Parameter(typeof(IServiceProvider), "serviceProvider");
            var instanceArg = Expression.Parameter(middleware, "middleware");

            var methodArguments = new Expression[parameters.Length];
            methodArguments[0] = httpContextArg;
            for (int i = 1; i < parameters.Length; i++)
            {
                var parameterType = parameters[i].ParameterType;
                if (parameterType.IsByRef)
                {
                    throw new NotSupportedException();
                }

                var parameterTypeExpression = new Expression[]
                {
                    providerArg,
                    Expression.Constant(parameterType, typeof(Type))
                };

                var getServiceCall = Expression.Call(GetServiceInfo, parameterTypeExpression);
                methodArguments[i] = Expression.Convert(getServiceCall, parameterType);
            }

            Expression middlewareInstanceArg = instanceArg;
            if (methodinfo.DeclaringType != typeof(T))
            {
                middlewareInstanceArg = Expression.Convert(middlewareInstanceArg, methodinfo.DeclaringType);
            }

            var body = Expression.Call(middlewareInstanceArg, methodinfo, methodArguments);

            var lambda = Expression.Lambda<Func<T, RouteContext, IServiceProvider, Task>>(body, instanceArg, httpContextArg, providerArg);

            return lambda.Compile();
        }

        private static object GetService(IServiceProvider sp, Type type)
        {
            var service = sp.GetService(type);
            if (service == null)
            {
                throw new InvalidOperationException();
            }

            return service;
        }
    }
}
