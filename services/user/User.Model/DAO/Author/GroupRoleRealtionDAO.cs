using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    [SugarTable("t_sec_grouppermisson")]
    public class GroupRoleRealtionDAO: BaseDAO
    {
        public string MGroupID { set; get; }

        public string MRoleID { set; get; }

        public string MOrgID { set; get; }
    }
}
