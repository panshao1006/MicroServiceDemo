using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ConfigurationCenter
{
    public class ConfigurationCenterSource: IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new ConfigurationCenterProvider();
        }
    }
}
