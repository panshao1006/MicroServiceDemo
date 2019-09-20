using Core.EventBus;
using Core.EventBus.Model;
using Core.EventBus.Model.Organization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.BLL.Author;
using User.Model;

namespace User.BLL.EventHandler
{
    public class OrganizationCreatedEventHandler : IEventHandler<OrganizationCreatedEvent>
    {
        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(OrganizationCreatedEvent));
        }

        public Task<bool> HandleAsync(OrganizationCreatedEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            //处理逻辑
            OperationResult operationResult = new AuthorBusiness().AddAuthor(@event.UserId, @event.OrgId);

            return new Task<bool>(() => operationResult.Success);
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
           return CanHandle(@event) ? HandleAsync((OrganizationCreatedEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
