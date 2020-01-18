using Core.EventBus.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggregateUser.Event
{
    /// <summary>
    /// 用户等待激活事件
    /// </summary>
    public class UserWaitActiveEvent : IEvent
    {
        public Guid Id { get; }

        public DateTime Timestamp { get; }

        public UserWaitActiveEvent()
        {
            Id = new Guid();
            Timestamp = DateTime.Now;
        }

        public string UserId { set; get; }

        public string Subject { set; get; }

        public string EmailContent { set; get; }

        public string EmailAddress { set; get; }
    }
}
