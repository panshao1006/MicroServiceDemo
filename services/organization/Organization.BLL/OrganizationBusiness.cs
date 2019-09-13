using Organization.DAL;
using Organization.Model;
using Organization.Model.Model;
using System;

namespace Organization.BLL
{
    public class OrganizationBusiness
    {
        OrganizationRepository _dal = new OrganizationRepository();

        public OperationResult CreateOrganization(OrganizationModel org)
        {
            OperationResult result = new OperationResult();

            int effRow = _dal.CreateOrganization(org);

            return result;
        }
    }
}
