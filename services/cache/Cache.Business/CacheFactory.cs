using System;

namespace Cache.BLL
{
    /// <summary>
    /// 缓存工厂类
    /// </summary>
    public class CacheFactory
    {
        /// <summary>
        /// 获取缓存业务实例
        /// </summary>
        /// <param name="cacheType"></param>
        /// <returns></returns>
        public static ICacheBusiness Instance(string cacheType)
        {
            switch (cacheType)
            {
                case "redis":
                    return new RedisCacheBusiness();
            }

            return null;
        }
    }
}
