using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    /// <summary>
    /// 用户角色
    /// </summary>
    [SugarTable("t_sec_role")]
    public class RoleDAO : BaseDAO
    {
        /// <summary>
        /// 权限所属应用ID
        /// </summary>
        public string MAppID { set; get; }

        public string MOrgID { set; get; }

        public string MName { set; get; }

        
    }
}
