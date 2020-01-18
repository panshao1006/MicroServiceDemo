using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Repository.PO
{
    public class RolePO : BasePO
    {
        public string MAppID { set; get; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public string MOrgID { set; get; }

        /// <summary>
        /// 角色多语言
        /// </summary>
        public List<RoleLanguagePO> Languages { set; get; }
    }
}
