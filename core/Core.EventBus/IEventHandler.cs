using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.EventBus
{
    public interface IEventHandler
    {
        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken));


        bool CanHandle(IEvent @event);
    }


    public interface IEventHandler<in T> : IEventHandler where T : IEvent
    {
        Task<bool> HandleAsync(T @event, CancellationToken cancellationToken = default(CancellationToken));
    }
}
