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

        /// <summary>
        /// 创建一个组织
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        public OperationResult CreateOrganization(OrganizationModel org)
        {
            OperationResult result = new OperationResult();

            int effRow = _dal.CreateOrganization(org);

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
    }
}
