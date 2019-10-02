using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO.Author
{
    public class RoleDAO : BaseDAO
    {
        public string MOrgID { set; get; }

        public string MName { set; get; }

        /// <summary>
        /// 权限所属引用ID
        /// </summary>
        public string MAppID { set; get; }

        public string MNumber { set; get; }

        public string MIndex { set; get; }
    }
}
