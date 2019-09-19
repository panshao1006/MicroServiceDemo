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
            _eventQueue = new RabbitQueue();

            _eventHandlers = eventHandlers;
        }

        private void EventQueue_EventPushed(object sender, EventProcessedEventArgs e)
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
        public void Subscribe()
        {
            _eventQueue.ReceivedEvent += EventQueue_EventPushed;
        }


        private bool disposedValue = false; 
        void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._eventQueue.ReceivedEvent -= EventQueue_EventPushed;
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
