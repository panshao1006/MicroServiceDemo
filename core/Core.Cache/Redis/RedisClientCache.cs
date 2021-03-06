﻿using Core.Common;
using Newtonsoft.Json;
using System;

namespace Core.Cache.Redis
{
    public class RedisClientCache : ICache
    {
        private string _redisHost;

        private string _redisPort;

        private string _redisPassword;

        private string _redisDataBaseName;

        public RedisClientCache()
        {
            _redisHost = ConfigurationManager.AppSetting("RedisHost");

            _redisPort = ConfigurationManager.AppSetting("RedisPort");

            _redisPassword = ConfigurationManager.AppSetting("RedisPassword");

            _redisDataBaseName = ConfigurationManager.AppSetting("RedisDateBase");

            _redisDataBaseName = string.IsNullOrWhiteSpace(_redisDataBaseName) ? "1" : _redisDataBaseName;

            var csredis = new CSRedis.CSRedisClient($"{_redisHost}:{_redisPort},password={_redisPassword},defaultDatabase={_redisDataBaseName},poolsize=50,ssl=false,writeBuffer=10240");
            //初始化 RedisHelper
            RedisHelper.Initialization(csredis);
        }

        #region 公有方法
        /// <summary>
        /// 新增一个缓存
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public bool Add(CacheModel cache)
        {
            bool result = true;

            if (RedisHelper.Exists(cache.Key))
            {
                throw new Exception("缓存key已经存在");
            }

            string data = JsonConvert.SerializeObject(cache.Data);

            int expireTime = cache.ExpireTime != null ? cache.ExpireTime.Value : -1;

            result = RedisHelper.Set(cache.Key, data, expireTime);

            return result;
        }


        /// <summary>
        /// 释放存在缓存键值
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public bool IsExistCacheKey(CacheFilter filter)
        {
            return RedisHelper.Exists(filter.Key);
        }


        private void AddCollectionCache(CacheModel cache)
        {
            //string collectionName = cache.CollectionName;

            //string key = cache.Key;

            //string data = JsonConvert.SerializeObject(cache.Data);

            //int expireTime = cache.ExpireTime != null ? cache.ExpireTime.Value : -1;

            //RedisHelper.SAdd(cache.Key, data, expireTime);
        }


        public bool Delete(CacheFilter filter)
        {
            if (!RedisHelper.Exists(filter.Key))
            {
                return false;
            }

            long deleteRowCount = RedisHelper.Del(filter.Key);

            return deleteRowCount > 0;
        }


        /// <summary>
        /// 查询缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public T Query<T>(CacheFilter filter)
        { 
            if (!RedisHelper.Exists(filter.Key))
            {
                return default(T);
            }

            string data = RedisHelper.Get<string>(filter.Key);

            if (string.IsNullOrWhiteSpace(data))
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(data);
        }


        /// <summary>
        /// 更新缓存
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public bool Update(CacheModel cache)
        {
            if (!RedisHelper.Exists(cache.Key))
            {
                return false;
            }

            if (Delete(new CacheFilter() { Key = cache.Key }))
            {
                return Add(cache);
            }

            return false;
        }

        void ICache.Delete(CacheFilter filter)
        {
            throw new NotImplementedException();
        }

        void ICache.Update(CacheModel cache)
        {
            if (!RedisHelper.Exists(cache.Key))
            {
                return;
            }

            if(Delete( new CacheFilter() { Key = cache.Key }))
            {
                Add(cache);
            }
        }
        #endregion

        #region 私有方法
        //public 

        #endregion
    }
}
