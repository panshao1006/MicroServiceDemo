using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.Common;
using Core.EventBus.Model;

namespace Core.EventBus
{
    public class RabbitMQEventBus : IEventBus
    {
        private RabbitQueue _eventQueue;

        private List<IEventHandler> _eventHandlers;

        private string _mqHost;

        private string _mqUser;

        private string _mqPassword;

        private IEventHandlerExecutionContext _eventHandlerExecutionContext;

        public RabbitMQEventBus(IEventHandlerExecutionContext eventHandlerExecutionContext)
        {
            _mqHost = ConfigurationManager.AppSetting("RabbitMQHost");
            _mqUser = ConfigurationManager.AppSetting("RabbitMQUser");
            _mqPassword = ConfigurationManager.AppSetting("RabbitMQPassword");

            _eventQueue = new RabbitQueue(_mqHost, _mqUser, _mqPassword);

            _eventHandlerExecutionContext = eventHandlerExecutionContext;

            
        }

        private void EventQueue_EventReceive(object sender, EventProcessedEventArgs e)
        {
            _eventHandlers = _eventHandlerExecutionContext.GetEventHandlers();

            var mathcHanderList = (from eh in this._eventHandlers
                                   where eh.CanHandle(e.Event)
                                   select eh).ToList();

            mathcHanderList.ForEach(async eh => await eh.HandleAsync(e.Event));
        }

        /// <summary>
        /// 发布
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken)) where TEvent : class ,IEvent
        {
            return  Task.Factory.StartNew(() => _eventQueue.Send(@event));
        }

        /// <summary>
        /// 订阅
        /// </summary>
        public void Subscribe<TEvent , TEventHandler>() where TEvent : IEvent where TEventHandler:IEventHandler
        {
            _eventHandlerExecutionContext.HandlerRegister<TEventHandler>();

            _eventQueue.ReceivedEvent += EventQueue_EventReceive;

            string queueName = typeof(TEvent).FullName;

            _eventQueue.Receive<TEvent>(queueName);
        }

        /// <summary>
        /// 事件处理是否已经注册过了
        /// </summary>
        /// <param name="handlerType"></param>
        /// <returns></returns>
        public bool HandlerRegistered(Type handlerType)
        {
            var result = false;

            foreach(IEventHandler handler in _eventHandlers)
            {
                if(handler.GetType() == handlerType)
                {
                    result= true;
                    break;
                }
            }

            return result;
        }


        private bool disposedValue = false; 
        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._eventQueue.ReceivedEvent -= EventQueue_EventReceive;
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
