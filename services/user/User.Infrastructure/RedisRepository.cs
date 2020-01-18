using Core.Cache;
using Core.Cache.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using User.DTO;

namespace User.Infrastructure
{
    public class RedisRepository
    {
        public static void SaveUserToken(TokenDTO token)
        {
            RedisClientCache redisClient = new RedisClientCache();

            CacheModel cache = new CacheModel()
            {
                Key = token.TokenId,
                Data = token,
                
            };

            redisClient.Add(cache);
        }
    }
}
