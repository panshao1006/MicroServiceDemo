using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 新增一个缓存
        /// </summary>
        bool Add(CacheModel cache);

        /// <summary>
        /// 删除一个缓存
        /// </summary>
        void Delete(CacheFilter filter);

        /// <summary>
        /// 更新缓存
        /// </summary>
        void Update(CacheModel cache);

        /// <summary>
        /// 查询缓存
        /// </summary>
        T Query<T>(CacheFilter filter);
    }
}
