using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
    }
}
