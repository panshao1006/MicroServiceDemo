using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus
{
    public class RabbitMQEventHandlerExecutionContext : IEventHandlerExecutionContext
    {
        private List<IEventHandler> _eventHandlers;

        private IServiceCollection _services;

        public RabbitMQEventHandlerExecutionContext(IServiceCollection services)
        {
            _eventHandlers = new List<IEventHandler>();

            _services = services;
        }

        /// <summary>
        /// 获取事件
        /// </summary>
        public List<IEventHandler> GetEventHandlers()
        {
            return _eventHandlers;
        }


        /// <summary>
        /// 事件处理是否已经注册过了
        /// </summary>
        /// <param name="handlerType"></param>
        /// <returns></returns>
        private bool HandlerRegistered(Type handlerType)
        {
            var result = false;

            foreach (IEventHandler handler in _eventHandlers)
            {
                if (handler.GetType() == handlerType)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        /// <typeparam name="TEventHandler"></typeparam>
        public void HandlerRegister<TEventHandler>() where TEventHandler : IEventHandler
        {
            if (!HandlerRegistered(typeof(TEventHandler)))
            {
                _eventHandlers.Add(_services.BuildServiceProvider().GetRequiredService<TEventHandler>());
            }
        }

    }
}
