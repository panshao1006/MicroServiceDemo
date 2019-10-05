using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    [SugarTable("t_sec_grouprole")]
    public class GroupRoleRealtionDAO: BaseDAO
    {
        public string MOrgID { set; get; }

        public string MGroupID { set; get; }

        public string MRoleID { set; get; }

       
    }
}
