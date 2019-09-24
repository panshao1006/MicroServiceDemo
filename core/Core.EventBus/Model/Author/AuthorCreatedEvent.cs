using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model.Author
{
    public class AuthorCreatedEvent: BaseEvent , IEvent
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public string OrgId { set; get; }

        /// <summary>
        /// 权限ID
        /// </summary>
        public string UserId { set; get; }
    }
}
