using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model.Email
{
    public class EmailNotificationEvent : BaseEvent, IEvent
    {
        /// <summary>
        /// 邮件
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Content { set; get; }
    }
}
