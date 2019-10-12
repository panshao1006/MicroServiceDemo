using Core.Common;
using Core.Context;
using Core.EventBus;
using Core.EventBus.Model.Organization;
using Core.ExceptionHandle;
using Core.Log;
using Core.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using User.BLL.EventHandler;
using User.Common.DI;

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

            services.UseDIRegister();

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
            eventBus.Subscribe<OrganizationCreatedEvent , OrganizationCreatedEventHandler>();

            app.UseTokenContext();
            app.UseCustomMiddleware();
            app.UseExceptionHandle();

            app.UseMvc();

        }
    }
}
