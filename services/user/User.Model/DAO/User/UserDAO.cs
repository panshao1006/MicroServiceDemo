using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.User
{
    [SugarTable("t_sec_user")]
    public class UserDAO : BaseDAO
    {

        [SugarColumn(ColumnName = "MEmailAddress")]
        public string MEmail { set; get; }

        [SugarColumn(IsIgnore = true)]
        public string MName { set; get; }

        /// <summary>
        /// 名
        /// </summary>
        public string MFirstName { set; get; }

        /// <summary>
        /// 姓
        /// </summary>
        public string MLastName { set; get; }


        public string MPassword { set; get; }
    }
}
