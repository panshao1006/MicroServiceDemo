using Organization.Model;
using Organization.Model.DAO;
using Organization.Model.DTO;
using Organization.Model.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Interface.DAL
{
    public interface IOrganizationRepository
    {
        OrganizationDTO CreateOrganization(OrganizationDTO organization);

        OrganizationDAO GetOrganization(OrganizationFilter filter);

        List<OrganizationDAO> GetOrganizations(OrganizationFilter filter);

        OrganizationAttributeDAO GetOrganizationAttribute(OrganizationFilter filter);

        bool DeleteOrganziton(string id);

        bool Update(OrganizationDAO organization);

        bool Update(OrganizationDAO organization, OrganizationAttributeDAO organizationAttribute);
    }
}
