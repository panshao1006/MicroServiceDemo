using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    /// <summary>
    /// 用户组
    /// </summary>
    [SugarTable("t_sec_role")]
    public class GroupDAO : BaseDAO
    {
        /// <summary>
        /// 组织ID
        /// </summary>
        public string MOrgID { set; get; }

        /// <summary>
        /// 应用
        /// </summary>
        public string MAppID { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string MName { set; get; }
    }
}
