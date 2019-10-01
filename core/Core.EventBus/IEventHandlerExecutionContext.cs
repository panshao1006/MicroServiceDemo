using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus
{
    public interface IEventHandlerExecutionContext
    {
        List<IEventHandler> GetEventHandlers();

        void HandlerRegister<TEventHandler>() where TEventHandler : IEventHandler;
    }
}
