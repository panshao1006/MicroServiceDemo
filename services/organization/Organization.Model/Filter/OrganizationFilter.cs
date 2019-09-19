using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.Filter
{
    public class OrganizationFilter
    {
        public string Id { set; get; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { set; get; }

        /// <summary>
        /// 组织名称
        /// </summary>
        public string Name { set; get; }
    }
}
