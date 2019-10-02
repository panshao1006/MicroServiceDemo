using Core.EventBus;
using Core.EventBus.Model;
using Core.EventBus.Model.BaseData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseData.BLL.Account.EventHandler
{
    public class DefaultAccountEventHandler : IEventHandler<DefaultAccountCreateEvent>
    {
        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(DefaultAccountCreateEvent));
        }

        public Task<bool> HandleAsync(DefaultAccountCreateEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CanHandle(@event) ? HandleAsync((DefaultAccountCreateEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
