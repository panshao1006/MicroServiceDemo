using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace Core.ConfigurationCenter
{
    public class ConfigurationCenterProvider : ConfigurationProvider
    {
        private string _remoteAddress;

        public ConfigurationCenterProvider()
        {
            //var jsonConfig = new JsonConfigurationSource();
            //jsonConfig.FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            //jsonConfig.Path = "appsettings.json";
            //var jsonProvider = new JsonConfigurationProvider(jsonConfig);
            //jsonProvider.Load();

            //jsonProvider.TryGet("configurationcenter", out string serverAddress);

            //if (string.IsNullOrEmpty(serverAddress))
            //{
            //    throw new Exception("Can not find myconfigServer's address from appsettings.json");
            //}
           
            _remoteAddress = "http://localhost:5000/api/v1/configurations";
        }

        /// <summary>
        /// 尝试从远程配置中心读取配置信息，当成功从配置中心读取信息的时候把配置写到本地的myconfig.json文件中，当配置中心无法访问的时候尝试从本地文件恢复配置。
        /// </summary>
        public async override void Load()
        {
            var response = "";
            try
            {
                var client = new HttpClient();

                response = await client.GetStringAsync(_remoteAddress);

                WriteToLocal(response);
            }
            catch (Exception ex)
            {
                response = ReadFromLocal();
            }

            if (string.IsNullOrEmpty(response))
            {
                throw new Exception("Can not request configs from remote config center .");
            }

            var configs = JsonConvert.DeserializeObject<List<System.Collections.Generic.KeyValuePair<string, string>>>(response);

            Data = new ConcurrentDictionary<string, string>();

            configs.ForEach(c =>
            {
                Data.Add(c);
            });
        }

        private void WriteToLocal(string resp)
        {
            var file = Directory.GetCurrentDirectory() + "/myconfig.json";
            File.WriteAllText(file, resp);
        }

        private string ReadFromLocal()
        {
            var file = Directory.GetCurrentDirectory() + "/myconfig.json";
            return File.ReadAllText(file);
        }
    }
}
