using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus
{
    public interface IEventSubscriber : IDisposable
    {
        void Subscribe<TEvent, TEventHandler>() where TEvent : IEvent where TEventHandler : IEventHandler;
    }
}
