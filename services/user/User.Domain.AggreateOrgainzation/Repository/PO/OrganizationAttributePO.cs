using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class OrganizationAttributePO : BasePO
    {
        public string MOrgID { set; get; }

        public OrganizationPO Organization { set; get; }
    }
}
