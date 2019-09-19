using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Core.EventBus.Model;

namespace Core.EventBus
{
    /// <summary>
    /// 队列载体
    /// </summary>
    public interface IEventQueue
    {
        void Send<T>(T @event) where T : class , IEvent;

        /// <summary>
        /// 收到事件时处理方式
        /// </summary>
        void Receive();
    }
}
