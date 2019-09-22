using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model.Auth
{
    [SugarTable("t_sec_roleuser")]
    public class UserRoleRelationModel : BaseModel
    {
        public string MUserID { set; get; }

        public string MRoleID { set; get; }

        public string MOrgID { set; get; }
    }
}
