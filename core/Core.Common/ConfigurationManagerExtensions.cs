using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public static class ConfigurationManagerExtensions
    {
        public static void InstanceConfigurationManager(this IApplicationBuilder app, IConfiguration configuration)
        {
            ConfigurationManager.Instance(configuration);
        }


        public static void InstanceConfigurationManager(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationManager.Instance(configuration);
        }
    }
}
