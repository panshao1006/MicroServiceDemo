﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus
{
    public interface IEventSubscriber : IDisposable
    {
        void Subscribe();
    }
}
