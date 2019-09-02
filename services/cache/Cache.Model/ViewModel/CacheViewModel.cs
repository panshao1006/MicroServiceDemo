using System;
using System.Collections.Generic;
using System.Text;

namespace Cache.Model.ViewModel
{
    public class CacheViewModel
    {
        /// <summary>
        /// 缓存key
        /// </summary>
        public string Key { set; get; }

        /// <summary>
        /// 缓存值
        /// </summary>
        public string Value { set; get; }
    }
}
