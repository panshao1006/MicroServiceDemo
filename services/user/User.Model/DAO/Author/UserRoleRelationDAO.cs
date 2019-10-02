using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    [SugarTable("t_sec_userrole")]
    public class UserRoleRelationDAO : BaseDAO
    {
        public string MUserID { set; get; }

        public string MRoleID { set; get; }

        public string MOrgID { set; get; }
    }
}
