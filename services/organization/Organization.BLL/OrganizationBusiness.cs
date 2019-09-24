using Core.EventBus;
using Core.EventBus.Model.Organization;
using Organization.DAL;
using Organization.Model;
using Organization.Model.Filter;
using Organization.Model.Model;
using Organization.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace Organization.BLL
{
    public class OrganizationBusiness
    {
        OrganizationRepository _dal = new OrganizationRepository();

        IEnumerable<IEventHandler> _eventHandlers;

        IEventBus _eventBus;
        
        public OrganizationBusiness()
        {
            //_eventHandlers = new IEnumerable<IEventHandler>();

            _eventBus = new RabbitMQEventBus(_eventHandlers);
        }

        /// <summary>
        /// 创建一个组织
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        public OperationResult CreateOrganization(OrganizationModel organization)
        {
            OperationResult result = new OperationResult();

            OrganizationModel tempOrganization = _dal.CreateOrganization(organization);

            if (tempOrganization != null)
            {
                OrganizationCreatedEvent @event = new OrganizationCreatedEvent()
                {
                    OrgId = organization.MItemID,
                    UserId = organization.MStateID
                };


                _eventBus.PublishAsync<OrganizationCreatedEvent>(@event);
            }

            result.Success = organization != null;
            result.ObjectId = organization.MItemID;

            return result;
        }

        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<OrganizationViewModel> GetList(OrganizationFilter filter)
        {
            List<OrganizationModel> orgList = _dal.GetList(filter);

            List<OrganizationViewModel> result = new OrganizationViewModel().ConvertViewModel(orgList);

            return result;
        }

        /// <summary>
        /// 获取组织viewmodel
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public OrganizationViewModel Get(OrganizationFilter filter)
        {
            OrganizationModel organization = GetOrganization(filter);

            OrganizationViewModel result = new OrganizationViewModel().ConvertViewModel(organization);

            return result;
        }

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public OrganizationModel GetOrganization(OrganizationFilter filter)
        {
            OrganizationModel organization = _dal.Get(filter);

            return organization;
        }


        /// <summary>
        /// 删除组织
        /// </summary>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public OperationResult Delete(string id)
        {
            OperationResult result = new OperationResult();

            result.Success = _dal.Delete(id) > 0;

            return result;
        }


        /// <summary>
        /// 更新组织状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OperationResult UpdateOrganizationStatus(string id)
        {
            OperationResult result = new OperationResult();

            OrganizationModel organization = GetOrganization(new OrganizationFilter() { Id = id });

            if (organization == null)
            {
                result.Success = false;
                result.Messages.Add($"Organization is not exist:{id}");

                return result;
            }

            organization.MIsActive = true;

            result.Success = _dal.Update(organization);

            return result;
        }
    }
}
