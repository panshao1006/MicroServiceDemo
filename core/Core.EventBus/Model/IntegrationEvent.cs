using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model
{
    /// <summary>
    /// 事件
    /// </summary>
    public class IntegrationEvent
    {
        public string Id { set; get; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// 事件数据
        /// </summary>
        public object Data { set; get; }
    }
}
