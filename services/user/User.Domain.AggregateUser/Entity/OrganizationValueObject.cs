using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggregateUser.Entity
{
    /// <summary>
    /// 组织的值对象
    /// </summary>
    public class OrganizationValueObject
    {
        /// <summary>
        /// 组织创建者
        /// </summary>
        public string MasterId { set; get; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 0 试用组织 1付费组织
        /// </summary>
        public int Type { set; get; }

        /// <summary>
        /// 组织版本
        /// </summary>
        public int Version { set; get; }

        /// <summary>
        /// 组织角色
        /// </summary>
        public string RoleName { set; get; }

    }
}
