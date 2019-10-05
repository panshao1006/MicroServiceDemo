using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    [SugarTable("t_sec_grouppermisson")]
    public class GroupPermissionRelationDAO : BaseDAO
    {
        public string MOrgID { set; get; }

        public string MGroupID { set; get; }

        public string MPermissionID { set; get; }

        /// <summary>
        /// 操作权限
        /// </summary>
        public string MRightType { set; get; }
    }
}
