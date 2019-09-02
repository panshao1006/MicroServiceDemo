using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Common.Pipeline
{
    /// <summary>
    /// 管道创建
    /// </summary>
    public class PipelineBuilder : IPipelineBuilder
    {
        private readonly IList<Func<CustomRequestDelegate, CustomRequestDelegate>> _middlewares;

        public IServiceProvider ApplicationServices { get; }


        public PipelineBuilder(IServiceProvider provider)
        {
            ApplicationServices = provider;
            _middlewares = new List<Func<CustomRequestDelegate, CustomRequestDelegate>>();
        }


        public PipelineBuilder(IPipelineBuilder builder)
        {
            ApplicationServices = builder.ApplicationServices;
            _middlewares = new List<Func<CustomRequestDelegate, CustomRequestDelegate>>();
        }


        public CustomRequestDelegate Build()
        {
            CustomRequestDelegate app = context =>
            {
                context.HttpContext.Response.StatusCode = 404;
                return Task.CompletedTask;
            };

            foreach (var component in _middlewares.Reverse())
            {
                app = component(app);
            }

            return app;
        }

        IPipelineBuilder IPipelineBuilder.New()
        {
            throw new NotImplementedException();
        }

        public PipelineBuilder Use(Func<CustomRequestDelegate, CustomRequestDelegate> middleware)
        {
            _middlewares.Add(middleware);

            return this;
        }
    }
}
