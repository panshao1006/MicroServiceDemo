using System;
using System.Collections.Generic;
using System.Text;

namespace Cache.Model
{
    /// <summary>
    /// 缓存操作的返回对象
    /// </summary>
    public class CacheResultModel
    {
        /// <summary>
        /// 成功标志
        /// </summary>
        public bool Success { set; get; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { set; get; }

        /// <summary>
        /// 多个消息
        /// </summary>
        public List<string> Messages { set; get; }
    }
}
