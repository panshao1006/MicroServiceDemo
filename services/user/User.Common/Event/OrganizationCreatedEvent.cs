using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Common.Event
{
    public class OrganizationCreatedEvent : IEvent
    {
        public Guid Id { get; }

        public DateTime Timestamp { get; }


        public OrganizationCreatedEvent()
        {

        }
    }
}
