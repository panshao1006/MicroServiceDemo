using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using User.Infrastructure;

namespace User.Domain.AggreateOrgainzation.Entity
{
    public class Organization : AggregateRoot
    {
        /// <summary>
        /// 组织名称
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// 法定名称
        /// </summary>
        public string LegalName { get; protected set; }


        /// <summary>
        /// 本位币
        /// </summary>
        public string BaseCurrencyId { get; protected set; }

        /// <summary>
        /// 创建者Id
        /// </summary>
        public string MasterUserId { get; protected set; }


        /// <summary>
        /// 组织对应的用户
        /// </summary>
        public UserValueObject User { get; protected set; }

        public List<Role> Roles { get; protected set; }

        public List<Permission> Permissions { get; protected set; }

        public List<UserRoleRelation> UserRoleRelations { get; protected set; }


        public List<RolePermissionRelation> RolePermissionRelations { get; protected set; }


        public List<UserOrganizationRelation> UserOrganizationRelations { get; protected set; }

        
        /// <summary>
        /// 组织的其他属性
        /// </summary>
        public OrganizationAttribute OrganizationAttribute { get; protected set; }
         

        public Organization(string id , string name , string masterUserId , UserValueObject user , List<Role> roles , List<Permission> permissions)
        {
            this.Id = id;

            User = user;

            Roles = roles;

            Permissions = permissions;

            MasterUserId = masterUserId;
        }


        /// <summary>
        /// 创建一个组织
        /// </summary>
        /// <returns></returns>
        public OperationResult CreateOrganization()
        {
            OperationResult result = new OperationResult();

            //1.组织信息初始化
            Create();

            result = Validate();

            //2.创建权限信息
            
            UserRoleRelation userRoleRelation = CreateUserRoleRelation();

            UserRoleRelations.Add(userRoleRelation);

            //3关键管理员角色权限
            RolePermissionRelations = CreateRolePermission(userRoleRelation.Id);

            //4创建组织和用户的对应关系
            UserOrganizationRelation userOrganizationRelation = new UserOrganizationRelation(Id, MasterUserId);
            userOrganizationRelation.CreateRealtion();

            UserOrganizationRelations.Add(userOrganizationRelation);

            

            if (!result.Success)
            {
                return result;
            }

            return result;
        }


        public UserRoleRelation CreateUserRoleRelation()
        {
            var adminRole = Roles.First(x => x.Id == "10000");

            if(adminRole == null)
            {
                throw new Exception("无法找到管理员角色");
            }

            UserRoleRelation roleRelation = new UserRoleRelation(Id, MasterUserId, adminRole.Id);
            roleRelation.CreateUserRoleRelation();
            return roleRelation;
            
        }

        /// <summary>
        /// 创建角色和权限的对应关系
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RolePermissionRelation> CreateRolePermission(string roleId)
        {
            var result = new List<RolePermissionRelation>();

            if(Permissions==null || Permissions.Count == 0)
            {
                throw new Exception("无法找到管理员角色的权限");
            }

            foreach(var permission in Permissions)
            {
                var rolePermission = new RolePermissionRelation(Id, roleId, permission.Id, 1111);
                rolePermission.CreateRolePermission();
                result.Add(rolePermission);

            }

            return result;
        }


        /// <summary>
        /// 数据校验
        /// </summary>
        /// <returns></returns>
        public OperationResult Validate()
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(Name))
            {
                result.Messages.Add("组织名称不能为空");
            }

            if (string.IsNullOrWhiteSpace(LegalName))
            {
                result.Messages.Add("法定名称不能为空");
            }
            
            if (string.IsNullOrWhiteSpace(MasterUserId))
            {
                result.Messages.Add("创建者不能为空");
            }

            OrganizationAttribute = new OrganizationAttribute();
            var attributeResult = OrganizationAttribute.Create(Id, BaseCurrencyId);

            result.Messages.AddRange(attributeResult.Messages);

            result.Success = result.Messages.Count == 0;

            return result;
        }

    }
}
