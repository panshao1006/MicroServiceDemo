using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Repository.PO
{
    public class RoleLanguagePO : BaseLanguagePO
    {
        public string MOrgID { set; get; }

        public RolePO Role { set; get; }
    }
}
