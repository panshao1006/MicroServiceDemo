using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model.BaseData
{
    public class DefaultAccountCreateEvent : BaseEvent, IEvent
    {
        public int AccountStandard { set; get; }

        public string OrganizationId { set; get; }
    }
}
