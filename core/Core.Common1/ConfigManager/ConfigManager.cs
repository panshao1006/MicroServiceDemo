using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IO;

namespace Core.Common.ConfigManager
{
    public class ConfigManager
    {
        private static IConfiguration _config;

        private static Dictionary<string , IConfiguration> _configDic;

        public static string AppSettings(string key)
        {
            if(_config == null)
            {
                var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json");

                _config = builder.Build();
            }

            return _config[key];
        }

        /// <summary>
        /// 自定义的文件路径
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T Settings<T>(string key , string fileName) where T : class, new()
        {
            IConfiguration config = GetConfiguration(fileName);

            if (config == null)
            {
                var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .Add(new JsonConfigurationSource { Path = fileName, ReloadOnChange = true });
                 //.AddJsonFile(fileName);

                config = builder.Build();

                _configDic.Add(fileName, config);
            }

            var appconfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appconfig;
        }


        /// <summary>
        /// 获取config
        /// </summary>
        /// <param name="fileName">配置文件名称</param>
        /// <returns></returns>
        private static IConfiguration GetConfiguration(string fileName)
        {
            _configDic = _configDic ?? new Dictionary<string, IConfiguration>();

            IConfiguration tempConfig;
            _configDic.TryGetValue(fileName, out tempConfig);


            return tempConfig;
        }
    }
}
