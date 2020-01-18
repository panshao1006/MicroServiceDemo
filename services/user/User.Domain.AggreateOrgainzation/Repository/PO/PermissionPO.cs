using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class PermissionPO : BasePO
    {
        public string MIndex { set; get; }

        public string MUrl { set; get; }

        /// <summary>
        /// 1菜单
        /// </summary>
        public int MType { set; get; }

        public List<PermissionLanguagePO> Languages { set; get; }
    }
}
