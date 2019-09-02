using Cache.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cache.BLL
{
    /// <summary>
    /// 缓存接口定义
    /// </summary>
    public interface ICacheBusiness
    {
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetValue<T>(string key);

        /// <summary>
        /// 设置值
        /// </summary>
        /// <returns></returns>
        CacheResultModel SetValue(string key, string value);


        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <returns></returns>
        CacheResultModel Delete(string key);
    }
}
