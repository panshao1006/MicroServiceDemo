using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.ConfigurationCenter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Log.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                                         .AddJsonFile("appsettings.json")
                                         .Build();

            CreateWebHostBuilder(args, configuration).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args , IConfiguration configuration) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, configBuiler) =>
            {
                configBuiler.UserConfigurationCenter();
            }).UseUrls(configuration["Server.Urls"])
                .UseStartup<Startup>();
    }
}
