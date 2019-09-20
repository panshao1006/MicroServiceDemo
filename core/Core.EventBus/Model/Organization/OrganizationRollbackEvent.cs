using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EventBus.Model.Organization
{
    /// <summary>
    /// 组织创建回滚事件（用于组织权限创建失败）
    /// </summary>
    public class OrganizationRollbackEvent : BaseEvent, IEvent
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public string OrgId { set; get; }
    }
}
