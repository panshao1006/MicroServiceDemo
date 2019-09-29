using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.DBRouter
{
    /// <summary>
    /// db存储DAO
    /// </summary>
    public class DBStoreDAO
    {
        public string MItemID { set; get; }

        public string MOrgID { set; get; }

        public string MStorageID { set; get; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string MDBName { set; get; }

        /// <summary>
        /// 数据库地址
        /// </summary>
        public string MDBServerName { set; get; }

        /// <summary>
        /// 数据库端口
        /// </summary>
        public string MDBServerPort { set; get; }

        /// <summary>
        /// 数据的用户名
        /// </summary>
        public string MUserName { set; get; }

        /// <summary>
        /// 数据库密码
        /// </summary>
        public string MPassword { set; get; }

       
    }
}
