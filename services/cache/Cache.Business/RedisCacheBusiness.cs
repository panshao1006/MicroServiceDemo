using System;
using System.Collections.Generic;
using System.Text;
using Cache.Model;
using Core.Common.ConfigManager;
using StackExchange.Redis;

namespace Cache.BLL
{
    /// <summary>
    /// redis缓存类型类
    /// </summary>
    public class RedisCacheBusiness : CacheBusinessBase
    {
        private ConnectionMultiplexer _redisClient { get; set; }

        private IDatabase _redisDB { get; set; }

        private string _redisConn;

        private string _redisConnKey = "RedisConnectionString";

        public RedisCacheBusiness()
        {
            _redisConn = ConfigManager.AppSettings(_redisConnKey);

            _redisClient = ConnectionMultiplexer.Connect(_redisConn);

            _redisDB = _redisClient.GetDatabase();
        }

        //public override T GetValue<T>(string key)
        //{
        //    var redisValue = _redisDB.StringGet(key);

        //    //return redisValue;
        //}

        public override CacheResultModel SetValue(string key, string value)
        {
            CacheResultModel result = new CacheResultModel();

            result.Success = _redisDB.StringSet(key , value);

            return result;
        }


    }
}
