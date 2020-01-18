using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class OrganizationPO : BasePO
    {
        public string MName { set; get; }

        public OrganizationAttributePO OrganizationAttribute { set; get; }
    }
}
