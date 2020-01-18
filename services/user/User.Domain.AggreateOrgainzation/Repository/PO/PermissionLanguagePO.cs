using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class PermissionLanguagePO : BaseLanguagePO
    {
        public string MName { set; get; }


        public PermissionPO Permission { set; get; }
    }
}
