using Gateway.Common;
using Gateway.Common.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            var configuration = new OcelotPipelineConfiguration
            {
                PreAuthenticationMiddleware = async (ctx, next) =>
                {
                    string token = ctx.HttpContext.Request.Headers["Token"].ToString();

                    string path = ctx.HttpContext.Request.Path;

                    string userApiAddress = "/api/v1/sessions";

                    if (path == userApiAddress)
                    {
                        await next.Invoke();
                    }

                    if (string.IsNullOrWhiteSpace(token))
                    {

                        return;
                    }

                    //调用UserAPI,校验权限

                    HttpClientUtility httpClient = new HttpClientUtility();

                    var result = httpClient.Get<ResultModel>(userApiAddress + "?token=" + token);

                    if (!result.Success)
                    {

                        return;
                    }

                    await next.Invoke();
                }
            };

            app.UseOcelot(configuration).Wait();
        }
    }
}
