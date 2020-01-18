using Core.Common;
using Core.Context;
using Core.EventBus;
using Core.EventBus.Model.Organization;
using Core.ExceptionHandle;
using Core.Log;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.Application.Event.Subscribe;
using User.Domain.AggregateUser.Event;
using User.Infrastructure;
using User.Infrastructure.Data;

namespace User.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstanceConfigurationManager(Configuration);

            //注入EFCore 上下文
            services.AddDbContextPool();

            //注入repository
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            //注入整个程序集
            services.AddGloabalIoc();

            //注入automapper文件
            services.AddAutoMappers();

            //事件总线
            services.AddSingleton<IEventHandlerExecutionContext>(sp => new RabbitMQEventHandlerExecutionContext(services));
            services.AddSingleton<IEventBus, RabbitMQEventBus>();

            services.AddMvc();
            
      
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime lifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<UserWaitActiveEvent, UserWaitActiveEventHandler>();

            app.UseTokenContext();
            app.UseRequestLog();
            app.UseExceptionHandle();

            app.UseMvc();

        }
    }
}
