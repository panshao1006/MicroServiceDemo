using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggreateOrgainzation.Entity
{
    public class UserOrganizationRelation : BaseEntity
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { set; get; }

        /// <summary>
        /// 用户组织关系
        /// </summary>

        public string UserId { set; get; }


        public UserOrganizationRelation(string organizationId , string userId)
        {
            OrganizationId = organizationId;
            UserId = userId;
        }

        public UserOrganizationRelation CreateRealtion()
        {
            Create();

            return this;
        }
    }
}
