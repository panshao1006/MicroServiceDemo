using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model.Auth
{
    [SugarTable("t_sec_usergroup")]
    public class UserGroupRelationModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string MItemID { set; get; }

        public string MUserID { set; get; }

        public string MGroupID { set; get; }

        public string MOrgID { set; get; }
    }
}
