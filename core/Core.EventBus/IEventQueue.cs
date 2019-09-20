using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;

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
        void Receive<TEvent>(string queueName) where TEvent : IEvent;
    }
}
