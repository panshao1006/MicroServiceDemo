using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class RoleLanguagePO : BaseLanguagePO
    {
        public string MName { set; get; }

        public RolePO Role { set; get; }
    }
}
