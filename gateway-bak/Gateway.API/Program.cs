using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Gateway.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new ConfigurationBuilder().AddCommandLine(args)
                .Build();
            string ip = config["ip"] ?? "127.0.0.1";
            string port = config["port"] ?? "5002";

            return WebHost.CreateDefaultBuilder(args)
                 .UseStartup<Startup>()
                 .UseUrls($"http://{ip}:{port}")
                 .Build();
        }
    }
}
