using System;
using System.Collections.Generic;
using System.Text;
using Gateway.Common.Pipeline;
using Gateway.Common.Route;
using Gateway.Middleware.Middleware;
using Gateway.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExtendMiddleware(this IApplicationBuilder builder)
        {
            //配置文件初始化
            InitConfiguration(builder);

            //中间件初始化
            var pipelineBuilder = new PipelineBuilder(builder.ApplicationServices);

            pipelineBuilder.InitPipeline();

            var firstDelegate = pipelineBuilder.Build();

            builder.Use(async (context, task) =>
            {
                var downstreamContext = new RouteContext(context);
                await firstDelegate.Invoke(downstreamContext);
            });


            return builder;
        }


        /// <summary>
        /// 初始化中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static IPipelineBuilder InitPipeline(this IPipelineBuilder builder)
        {
           return builder.UseMiddleware<RouteMiddleware>();
        }


        /// <summary>
        /// 配置文件的初始化话
        /// </summary>
        /// <param name="builder"></param>
        private static void InitConfiguration(IApplicationBuilder builder)
        {
            var routeConfig = builder.ApplicationServices.GetService<IOptions<FileConfiguration>>();

            if(routeConfig.Value == null)
            {
                throw new Exception("无法读取配置文件");
            }

            var routesFromConfig = routeConfig.Value.Routes;

            RouteContextHelper.Instance(routesFromConfig);
        }
    }
}
