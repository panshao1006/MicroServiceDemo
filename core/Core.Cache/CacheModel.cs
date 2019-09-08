using System;
using System.IO;

namespace Core.Cache
{
    public class CacheModel
    {
        public string Key { set; get; }

        public object Data { set; get; }

        /// <summary>
        /// 失效时间,单位秒
        /// </summary>
        public int? ExpireTime { set; get; }

        /// <summary>
        /// 缓存集合名称
        /// </summary>
        public string CollectionName { set; get; }

        /// <summary>
        /// 缓存类型
        /// </summary>
        public CacheType CacheType { set; get; }
    }
}
