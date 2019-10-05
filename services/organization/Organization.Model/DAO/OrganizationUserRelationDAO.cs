using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.DAO
{
    [SugarTable("t_bas_organizationuser")]
    public class OrganizationUserRelationDAO : BaseDAO
    {
        public string MUserID { set; get; }

        public string MOrgID { set; get; }
    }
}
