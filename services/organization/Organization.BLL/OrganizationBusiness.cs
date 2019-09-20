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
        public OperationResult CreateOrganization(OrganizationModel org)
        {
            OperationResult result = new OperationResult();

            int effRow = _dal.CreateOrganization(org);

            if (effRow > 0)
            {
                OrganizationCreatedEvent @event = new OrganizationCreatedEvent()
                {
                    OrgId = org.MItemID,
                    UserId = org.MStateID
                };


                _eventBus.PublishAsync<OrganizationCreatedEvent>(@event);
            }

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
    }
}
