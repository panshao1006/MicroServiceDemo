using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class RolePO : BasePO
    {
        public List<RoleLanguagePO> Languages { set; get; }
    }
}
