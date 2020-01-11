using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public static class WebBuilderExtensions
    {
        /// <summary>
        /// 配置站点启动端口
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IWebHostBuilder CustomUseUrls(this IWebHostBuilder hostBuilder)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                         .AddJsonFile("appsettings.json")
                                         .Build();

            var urls = configuration["ServerUrls"];

            hostBuilder.UseUrls(urls);

            return hostBuilder;
        }
    }
}
