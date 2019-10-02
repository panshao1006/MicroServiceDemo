using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model
{
    /// <summary>
    /// 事件
    /// </summary>
    public class BaseEvent
    {
        public Guid Id { get; }

        public DateTime Timestamp { get; }

        public List<string> Messages { set; get; }
    }
}
