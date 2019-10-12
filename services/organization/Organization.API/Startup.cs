using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.Context;
using Core.EventBus;
using Core.EventBus.Model.Author;
using Core.EventBus.Model.Organization;
using Core.ExceptionHandle;
using Core.Log;
using Core.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Organization.BLL.EventHandler;
using Organization.Common;

namespace Organization.API
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.InstanceConfigurationManager(Configuration);

            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<OrganizationRollbackEvent , OrganizationRollbackHandler>();
            eventBus.Subscribe<AuthorCreatedEvent , AuthorCreatedHandler>();

            app.UseTokenContext();
            app.UseCustomMiddleware();
            app.UseExceptionHandle();

            app.UseMvc();
        }
    }
}
