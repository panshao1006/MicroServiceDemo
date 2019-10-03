using BaseData.Interface.BLL;
using BaseData.Model;
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
        IAccountBusiness _accountBusiness;
        public DefaultAccountEventHandler(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(DefaultAccountCreateEvent));
        }

        public Task<bool> HandleAsync(DefaultAccountCreateEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            OperationResult result = _accountBusiness.CreateDefaultAccount(@event.AccountStandard, @event.OrganizationId);

            return new Task<bool>(() => result.Success);
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CanHandle(@event) ? HandleAsync((DefaultAccountCreateEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
