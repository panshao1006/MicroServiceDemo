using Core.EventBus;
using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace User.Common.Event
{
    public class OrganizationCreatedEventHandler : IEventHandler<OrganizationCreatedEvent>
    {
        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(OrganizationCreatedEvent));
        }

        public Task<bool> HandleAsync(OrganizationCreatedEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            //正在的事件处理
            throw new NotImplementedException();
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
           return CanHandle(@event) ? HandleAsync((OrganizationCreatedEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
