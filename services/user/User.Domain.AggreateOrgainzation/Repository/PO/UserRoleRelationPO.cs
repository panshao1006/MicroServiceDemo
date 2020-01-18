using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class UserRoleRelationPO:BasePO
    {

        public string MOrgID { set; get; }
        public string MUserID { set; get; }

        public string MRoleID { set; get; }
    }
}
