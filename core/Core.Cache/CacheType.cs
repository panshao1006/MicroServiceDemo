using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Cache
{
    public enum CacheType
    {
        /// <summary>
        /// 集合缓存
        /// </summary>
        Collection = 1,

        /// <summary>
        /// 列表缓存
        /// </summary>
        List = 2,

        /// <summary>
        /// 键值对缓存
        /// </summary>
        KeyValue = 3,


    }
}
