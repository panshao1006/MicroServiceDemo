using Core.Common;
using Core.EventBus;
using Core.EventBus.Model.Author;
using Core.EventBus.Model.Organization;
using System;
using System.Collections.Generic;
using User.Interface.BLL;
using User.Interface.DAL;
using User.Model;
using User.Model.DAO.Author;

namespace User.BLL.Author
{
    /// <summary>
    /// 权限业务类
    /// </summary>
    public class AuthorBusiness : IAuthorBusiness
    {
        private IAuthorRepository _authorRepository;

        private IEventBus _eventBus;

        public AuthorBusiness(IEventBus eventBus, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _eventBus = eventBus;
        }

        /// <summary>
        /// 用户，组织创建权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public OperationResult AddAuthor(string userId, string orgId)
        {
            OperationResult result = new OperationResult();

            //用户对于的角色
            UserRoleRelationDAO userRoleRelation = new UserRoleRelationDAO()
            {
                MItemID = GuidUtility.GetGuid(),
                MUserID = userId,
                MOrgID = orgId,
                //管理员
                MRoleID = "10000"
            };

            //获取用户组模型
            UserGroupRelationDAO userGroupRelation = new UserGroupRelationDAO()
            {
                MItemID = GuidUtility.GetGuid(),
                MUserID = userId,
                MOrgID = orgId,
                MGroupID = "10000"
            };

            GroupRoleRealtionDAO groupRoleRealtion = new GroupRoleRealtionDAO()
            {
                MGroupID = "10000",
                MRoleID = "10000",
                MItemID = GuidUtility.GetGuid(),
            };

            //获取角色，权限关系模型
            List<RolePermisionRelationDAO> rolePermisionRelations = new List<RolePermisionRelationDAO>()
            {
                new RolePermisionRelationDAO()
                {
                    MItemID = GuidUtility.GetGuid(),
                    MRoleID = "10000",
                    MPermisonID = "10001",
                    MRigthType="11111",
                },
                new RolePermisionRelationDAO()
                {
                    MItemID = GuidUtility.GetGuid(),
                    MRoleID = "10000",
                    MPermisonID = "10002",
                    MRigthType="11111",
                },
                 new RolePermisionRelationDAO()
                {
                    MItemID = GuidUtility.GetGuid(),
                    MRoleID = "10000",
                    MPermisonID = "10003",
                    MRigthType="11111",
                },
                 new RolePermisionRelationDAO()
                {
                    MItemID = GuidUtility.GetGuid(),
                    MRoleID = "10000",
                    MPermisonID = "10004",
                    MRigthType="11111",
                },
                 new RolePermisionRelationDAO()
                {
                    MItemID = GuidUtility.GetGuid(),
                    MRoleID = "10000",
                    MPermisonID = "10005",
                    MRigthType="11111",
                }
            };

            try
            {
                result.Success = _authorRepository.AddAuthor(userGroupRelation, userRoleRelation, rolePermisionRelations, groupRoleRealtion);

                //如果成功，返回一个权限创建成功队列
                if (result.Success)
                {
                    AuthorCreatedEvent @event = new AuthorCreatedEvent() { OrgId = orgId, UserId = userId };
                    _eventBus.PublishAsync<AuthorCreatedEvent>(@event);
                }
                else
                {
                    OrganizationRollbackEvent @event = new OrganizationRollbackEvent() { OrgId = orgId };

                    _eventBus.PublishAsync<OrganizationRollbackEvent>(@event);
                }

            }
            catch (Exception ex)
            {
                //如果创建失败，发送一个组织回滚事件
                OrganizationRollbackEvent @event = new OrganizationRollbackEvent() { OrgId = orgId };

                _eventBus.PublishAsync<OrganizationRollbackEvent>(@event);
            }

            return result;
        }
    }
}
