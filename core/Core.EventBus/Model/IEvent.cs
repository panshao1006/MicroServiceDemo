using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model
{
    /// <summary>
    /// 事件
    /// </summary>
    public interface IEvent
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
    }
}
