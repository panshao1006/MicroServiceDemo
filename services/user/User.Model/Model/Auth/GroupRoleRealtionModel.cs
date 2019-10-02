using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model.Auth
{
    [SugarTable("t_sec_grouppermisson")]
    public class GroupRoleRealtionDAO
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string MItemID { set; get; }

        public string MGroupID { set; get; }

        public string MRoleID { set; get; }

        public string MOrgID { set; get; }
    }
}
