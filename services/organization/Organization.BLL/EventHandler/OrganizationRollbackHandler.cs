using Core.EventBus;
using Core.EventBus.Model;
using Core.EventBus.Model.Organization;
using Organization.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Organization.BLL.EventHandler
{
    /// <summary>
    /// 组织回滚事件处理
    /// </summary>
    public class OrganizationRollbackHandler : IEventHandler<OrganizationRollbackEvent>
    {
        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(OrganizationRollbackEvent));
        }

        public Task<bool> HandleAsync(OrganizationRollbackEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            OperationResult result = new OrganizationBusiness().Delete(@event.OrgId);

            return new Task<bool>(() =>  result.Success);
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CanHandle(@event) ? HandleAsync((OrganizationCreatedEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
