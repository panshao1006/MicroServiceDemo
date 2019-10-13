using Core.Common;
using Core.Http;
using Core.Log.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Log
{
    public class BaseLoggerFactory
    {
        private string _logServiceHost = ConfigurationManager.AppSetting("LogFactoryHost");

        private static BaseLoggerFactory _logFactory;

        private BaseLoggerFactory()
        {

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
        /// 写入日志
        /// </summary>
        /// <param name="log"></param>
        public void Write(LogDTO log)
        {
            HttpClientUtility httpClientUtility = new HttpClientUtility();

            httpClientUtility.PostAsync<LogDTO>(_logServiceHost, log);
        }


    }
}
