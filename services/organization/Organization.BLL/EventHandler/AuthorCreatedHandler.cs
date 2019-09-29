using Core.EventBus;
using Core.EventBus.Model;
using Core.EventBus.Model.Author;
using Organization.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Organization.BLL.EventHandler
{
    public class AuthorCreatedHandler : IEventHandler<AuthorCreatedEvent>
    {
        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(AuthorCreatedEvent));
        }

        public Task<bool> HandleAsync(AuthorCreatedEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            //更新组织的状态
            OperationResult result = new OrganizationBusiness().UpdateOrganization(@event.OrgId , true);

            return new Task<bool>(() => result.Success);
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CanHandle(@event) ? HandleAsync((AuthorCreatedEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
