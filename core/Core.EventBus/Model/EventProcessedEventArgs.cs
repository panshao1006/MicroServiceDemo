using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model
{
    public class EventProcessedEventArgs
    {
        public IEvent Event { set; get; }
    }
}
