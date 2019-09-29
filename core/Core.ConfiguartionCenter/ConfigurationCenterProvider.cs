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

        private string _environment;

        private string _appId;

        public ConfigurationCenterProvider()
        {
            var jsonConfigurationSource = new JsonConfigurationSource();

            jsonConfigurationSource.FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            jsonConfigurationSource.Path = "appsettings.json";
            var jsonConfigurationProvider = new JsonConfigurationProvider(jsonConfigurationSource);
            jsonConfigurationProvider.Load();

            jsonConfigurationProvider.TryGet("ConfigurationCenter:Host", out _remoteAddress);
            jsonConfigurationProvider.TryGet("ConfigurationCenter:Environment", out _environment);
            jsonConfigurationProvider.TryGet("ConfigurationCenter:AppId", out _appId);

            if (string.IsNullOrEmpty(_remoteAddress))
            {
                throw new Exception("Can not find configurationCenter remote address from appsettings.json");
            }

            if (string.IsNullOrEmpty(_environment))
            {
                throw new Exception("Can not find configurationCenter environment address from appsettings.json");
            }

            if (string.IsNullOrEmpty(_appId))
            {
                throw new Exception("Can not find configurationCenter appid address from appsettings.json");
            }
        }

        /// <summary>
        /// 尝试从远程配置中心读取配置信息，当成功从配置中心读取信息的时候把配置写到本地的配置文件中，当配置中心无法访问的时候尝试从本地文件恢复配置。
        /// </summary>
        public override void Load()
        {
            var response = "";
            try
            {
                var client = new HttpClient();

                response = client.GetStringAsync(_remoteAddress + $"?environment={_environment}&appid={_appId}").Result;

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

            var responseResult = JsonConvert.DeserializeObject<RespenseResult>(response);

            if (responseResult.Success && responseResult.Data != null)
            {
                var configs = JsonConvert.DeserializeObject<List<KeyValuePair<string , string>>>(responseResult.Data.ToString());

                Data = new ConcurrentDictionary<string, string>();

                configs.ForEach(c =>
                {
                    Data.Add(c);
                });
            }

           
        }

        private void WriteToLocal(string resp)
        {
            var file = Directory.GetCurrentDirectory() + "/configurationcenter.json";
            File.WriteAllText(file, resp);
        }

        private string ReadFromLocal()
        {
            var file = Directory.GetCurrentDirectory() + "/configurationcenter.json";
            return File.ReadAllText(file);
        }
    }
}
