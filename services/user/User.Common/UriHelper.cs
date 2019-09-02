using Core.Common.Communication;
using Core.Common.ConfigManager;
using Core.Common.ServiceFinder;
using System;
using System.Collections.Generic;
using System.Text;
using User.Model.Enum;

namespace User.Common
{
    /// <summary>
    /// url帮助类
    /// </summary>
    public class UriHelper
    {
        /// <summary>
        /// 获取完整的http请求地址
        /// </summary>
        /// <param name="serviceName"></param>
        /// <param name="pathName"></param>
        /// <returns></returns>
        public static string GetHttpRequestUri(string serviceName , string pathName)
        {
            //从配置文件中找到servicename
            string realServiceName = ConfigManager.AppSettings(serviceName);

            ConsulServiceFinder serviceFinder = new ConsulServiceFinder();

            string serviceHost = serviceFinder.GetServiceHttpAddress(realServiceName);

            if (string.IsNullOrWhiteSpace(serviceHost))
            {
                throw new Exception("not find any service by name:" + serviceName);
            }

            string servicePath = ConfigManager.AppSettings(pathName);

            if (string.IsNullOrWhiteSpace(servicePath))
            {
                throw new Exception("not find any path by name:" + servicePath);
            }

            string uri = $"{serviceHost}/{servicePath}";

            return uri;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="communicationType">通讯类型：1 http</param>
        /// <param name="serviceName"></param>
        /// <param name="pathName"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static T Post<T>(int communicationType , string serviceName, string pathName, Dictionary<string, string> postData)
        {
            string serviceUri = GetHttpRequestUri(serviceName, pathName);

            ICommunicationHelper client = CommunicationHelperFactory.GetInstance(communicationType);

            return client.Post<T>(serviceUri, postData);
        }
    }
}
