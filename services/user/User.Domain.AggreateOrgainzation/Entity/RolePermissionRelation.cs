using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggreateOrgainzation.Entity
{
    public class RolePermissionRelation : BaseEntity
    {
        public string OrganizationId { set; get; }


        public string RoleId { set; get; }


        public string PermissionId { set; get; }


        /// <summary>
        /// 权限值
        /// </summary>
        public int RightValue { set; get; }


        public RolePermissionRelation(string organizationId , string roleId , string permissionId , int rightValue)
        {
            OrganizationId = organizationId;
            RoleId = roleId;
            PermissionId = permissionId;
            RightValue = rightValue;
        }


        public RolePermissionRelation CreateRolePermission()
        {
            Create();

            return this;
        }
    }
}
