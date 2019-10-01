using Organization.Model;
using Organization.Model.DTO;
using Organization.Model.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Interface.BLL
{
    public interface IOrganizationBusiness
    {
        OperationResult CreateOrganization(OrganizationDTO organization);

        List<OrganizationDTO> GetOrganizations(OrganizationFilter filter);

        OrganizationDTO GetOrganization(OrganizationFilter filter);

        OperationResult DeleteOrganization(string id);

        OperationResult UpdateOrganization(string id, bool isActive);

        OperationResult UpdateOrganization(DetailedOrganizationDTO organization);
    }
}
