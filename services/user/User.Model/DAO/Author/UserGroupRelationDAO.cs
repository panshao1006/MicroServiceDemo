using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    [SugarTable("t_sec_usergroup")]
    public class UserGroupRelationDAO : BaseDAO
    {
        
        public string MUserID { set; get; }

        public string MGroupID { set; get; }

        public string MOrgID { set; get; }
    }
}
