using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core.Common;
using Core.ConfigurationCenter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace User.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>


             WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((context, configBuiler) =>
             {
                 configBuiler.UserConfigurationCenter();

             }).UseStartup<Startup>().CustomUseUrls() 
                 .Build();
    }
}
