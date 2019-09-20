using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model.Organization
{
    public class OrganizationCreatedEvent : BaseEvent , IEvent
    {
        public string OrgId { set; get; }

        public string UserId { set; get; }
    }
}
