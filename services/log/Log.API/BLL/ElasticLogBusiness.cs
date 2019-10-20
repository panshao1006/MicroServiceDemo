using Core.Common;
using Elasticsearch.Net;
using Log.API.Interface;
using Log.API.Model;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.BLL
{
    public class ElasticLogBusiness : ILoggerBusiness
    {
        private string _elasticHost = ConfigurationManager.AppSetting("ElasticHost");

        private ElasticClient _elasticClient;

        public ElasticLogBusiness()
        {
            var uri = new Uri(_elasticHost);
            var pool = new SingleNodeConnectionPool(uri);
            _elasticClient = new ElasticClient(new ConnectionSettings(pool));
        }

        /// <summary>
        /// 新增日志
        /// </summary>
        /// <param name="log"></param>
        public void AddLog(LogDTO log)
        {
            if (log == null)
            {
                return;
            }

            string indexName = string.IsNullOrWhiteSpace(log.AppName) ? "index_unkonw_appname" : "index_"+log.AppName.ToLower();

            _elasticClient.Index(log.Convert(), i => i.Index(indexName));

        }
    }
}
