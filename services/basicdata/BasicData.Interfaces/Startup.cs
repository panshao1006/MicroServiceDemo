using BasicData.Infrastructure;
using BasicData.Infrastructure.Data;
using Core.Common;
using Core.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BasicData.Interfaces
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //注入efcore上下文
            //services.AddDbContextPool<MysqlDbContext>(opts => opts.UseMySQL("server=localhost;user=root;database=jienorsys;port=3306;password=123456;SslMode=None"));

            //初始化配置文件
            services.InstanceConfigurationManager(Configuration);

            services.AddTransient(typeof(MysqlDbContext));

            //注入repository
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));

            //注入整个程序集
            services.AddGloabalIoc();
            
            //注入automapper文件
            services.AddAutoMappers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseTokenContext();
            app.UseMvc();
           
        }
    }
}
