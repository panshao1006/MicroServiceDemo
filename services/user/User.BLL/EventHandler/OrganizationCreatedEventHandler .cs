﻿using Core.EventBus;
using Core.EventBus.Model;
using Core.EventBus.Model.Organization;
using System.Threading;
using System.Threading.Tasks;
using User.Interface.BLL;
using User.Model;

namespace User.BLL.EventHandler
{
    public class OrganizationCreatedEventHandler : IEventHandler<OrganizationCreatedEvent>
    {
        IAuthorBusiness _authorBusiness;

        public OrganizationCreatedEventHandler(IAuthorBusiness authorBusiness)
        {
            _authorBusiness = authorBusiness;
        }

        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(OrganizationCreatedEvent));
        }

        public Task<bool> HandleAsync(OrganizationCreatedEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            //处理逻辑
            OperationResult operationResult = _authorBusiness.CreateAdminAuthor(@event.UserId, @event.OrgId);

            return new Task<bool>(() => operationResult.Success);
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
           return CanHandle(@event) ? HandleAsync((OrganizationCreatedEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
