using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    /// <summary>
    /// 权限项
    /// </summary>
    [SugarTable("t_sec_permissionitem")]
    public class PermisionDAO: BaseDAO
    {
        public string MName { set; get; }

        public string MParentID { set; get; }

        public string MAppID { set; get; }
    }
}
