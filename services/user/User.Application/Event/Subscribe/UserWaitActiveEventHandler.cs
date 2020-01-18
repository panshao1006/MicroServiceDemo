using Core.EventBus;
using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregateUser.Event;
using User.Domain.AggregateUser.Service;
using User.Infrastructure;

namespace User.Application.Event.Subscribe
{
    public class UserWaitActiveEventHandler : IEventHandler<UserWaitActiveEvent>
    {
        private UserDomainService _userDomainService;

        public UserWaitActiveEventHandler(UserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public bool CanHandle(IEvent @event)
        {
            return @event.GetType().Equals(typeof(UserWaitActiveEvent));
        }

        public Task<bool> HandleAsync(UserWaitActiveEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            OperationResult result = _userDomainService.SendActiveEmail(@event.UserId , @event.Subject , @event.EmailContent , @event.EmailAddress);

            return new Task<bool>(() => result.Success);
        }

        public Task<bool> HandleAsync(IEvent @event, CancellationToken cancellationToken = default(CancellationToken))
        {
            return CanHandle(@event) ? HandleAsync((UserWaitActiveEvent)@event, cancellationToken) : Task.FromResult(false);
        }
    }
}
