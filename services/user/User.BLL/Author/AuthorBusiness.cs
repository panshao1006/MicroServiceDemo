using Core.Common;
using Core.EventBus;
using Core.EventBus.Model.Organization;
using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.BLL;
using User.Interface.DAL;
using User.Model;
using User.Model.Model.Auth;

namespace User.BLL.Author
{
    /// <summary>
    /// 权限业务类
    /// </summary>
    public class AuthorBusiness : IAuthorBusiness
    {
        private IAuthorRepository _authorRepository;

        IEnumerable<IEventHandler> _eventHandlers;

        IEventBus _eventBus;

        public AuthorBusiness(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _eventBus = new RabbitMQEventBus(_eventHandlers);
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
            UserRoleRelationModel userRoleRelation = new UserRoleRelationModel()
            {
                MItemID = GuidUtility.GetGuid(),
                MUserID = userId,
                MOrgID = orgId,
                //管理员
                MRoleID = "5"
            };

            UserGroupRelationModel userGroupRelation = new UserGroupRelationModel()
            {
                MItemID = GuidUtility.GetGuid(),
                MUserID = userId,
                MOrgID = orgId,
                MGroupID = "1"
            };

            try
            {
                result.Success = _authorRepository.AddAuthor(userGroupRelation, userRoleRelation);
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
