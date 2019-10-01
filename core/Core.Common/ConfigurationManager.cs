using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public class ConfigurationManager
    {
        private static IConfiguration _configuation;

        private static ConfigurationManager _configurationManager;

        private ConfigurationManager(IConfiguration configuration)
        {
            _configuation = configuration;
        }

        public static ConfigurationManager Instance(IConfiguration configuration)
        {
            if (_configurationManager != null)
            {
                return _configurationManager;
            }

            _configurationManager = new ConfigurationManager(configuration);

            return _configurationManager;
        }

        public static string AppSetting(string key)
        {
            if (_configuation == null)
            {
                return "";
            }
            return _configuation[key];
        }
    }
}
