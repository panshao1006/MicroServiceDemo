using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Gateway.API
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
            services.AddMvc().AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddOcelot();

            services.AddCors(options =>
            {
                options.AddPolicy("DefaultCORS",
                builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseCors("DefaultCORS");

            var configuration = new OcelotPipelineConfiguration
            {
                PreAuthenticationMiddleware = async (ctx, next) =>
                {

                   await OcelotMiddlewareExtension.AuthenticationMiddlewareAsync(ctx, next);
                }
            };

            app.UseOcelot(configuration).Wait();

        }
    }
}
