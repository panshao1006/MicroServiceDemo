using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Core.EventBus.Model;

namespace Core.EventBus
{
    public class RabbitMQEventBus : IEventBus
    {
        private RabbitQueue _eventQueue;

        private readonly IEnumerable<IEventHandler> _eventHandlers;

        public RabbitMQEventBus(IEnumerable<IEventHandler> eventHandlers)
        {
            _eventQueue = new RabbitQueue("127.0.0.1","admin","admin");

            _eventHandlers = eventHandlers;
        }

        private void EventQueue_EventReceive(object sender, EventProcessedEventArgs e)
        {
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
        public void Subscribe<TEvent>() where TEvent : IEvent
        {
            _eventQueue.ReceivedEvent += EventQueue_EventReceive;

            string queueName = typeof(TEvent).FullName;

            _eventQueue.Receive<TEvent>(queueName);
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
