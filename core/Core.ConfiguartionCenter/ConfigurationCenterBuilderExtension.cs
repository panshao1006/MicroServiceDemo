using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ConfigurationCenter
{
    public static class ConfigurationCenterBuilderExtension
    {
        public static IConfigurationBuilder UserConfigurationCenter(
           this IConfigurationBuilder builder
           )
        {
            return builder.Add(new ChainedConfigurationSource());
        }
    }
}
