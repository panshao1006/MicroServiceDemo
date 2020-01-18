using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class RolePermissionRelationPO : BasePO
    {
        public string MOrgID { set; get; }

        public string MRoleID { set; get; }

        public string MPermissionID { set; get; }


    }
}
