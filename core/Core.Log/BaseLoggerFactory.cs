using System;
using System.Collections.Generic;
using System.Text;
using Core.Common;
using Core.Http;
using Core.Log.Model;

namespace Core.Log
{
    /// <summary>
    /// 日志工厂
    /// </summary>
    public class BaseLoggerFactory : ILogFactory
    {
        private string _host;

        private static BaseLoggerFactory _logFactory;

        private BaseLoggerFactory()
        {
            _host = ConfigurationManager.AppSetting("LogFactoryHost");

            if (string.IsNullOrWhiteSpace(_host))
            {
                throw new ArgumentNullException("LogFactoryHost 没有配置");
            }

        }

        public static BaseLoggerFactory Instance()
        {
            if(_logFactory == null)
            {
                _logFactory = new BaseLoggerFactory();
            }

            return _logFactory;
        }


        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="log"></param>
        public void Add(LogDTO log)
        {
            if (log == null)
                return;

            try
            {
                //插入日志
                HttpClientUtility httpClient = new HttpClientUtility();

                httpClient.PostAsync<LogDTO>(_host, log);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
