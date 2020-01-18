using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggreateOrgainzation.Entity
{
    public class UserRoleRelation:BaseEntity
    {
        public string OrganizationId { set; get; }

        public string UserId { set; get; }

        public string RoleId { set; get; }

        public UserRoleRelation(string organizationId , string userId , string roleId)
        {
            OrganizationId = organizationId;
            UserId = userId;
            RoleId = roleId;
        }

        public UserRoleRelation CreateUserRoleRelation()
        {
            Create();

            return this;
        }
    }
}
