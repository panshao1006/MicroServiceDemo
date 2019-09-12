using Organization.Model.Filter;
using Organization.Model.Model;
using System;

namespace Organization.DAL
{
    public class OrganizationRepository
    {
        public int CreateOrganization(OrganizationModel org)
        {
            return 1;
        }

        public OrganizationModel GetOrganization(OrganizationFilter filter)
        {
            return new OrganizationModel();
        }
    }
}
