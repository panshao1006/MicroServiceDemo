using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.DBRouter
{
    /// <summary>
    /// db存储DAO
    /// </summary>
    public class OrganizaitonStoreRelationDAO
    {
        public string MItemID { set; get; }

        public string MOrgID { set; get; }

        public string MStorageID { set; get; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public string MDBName { set; get; }

        /// <summary>
        /// 数据库地址
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert =true)]
        public string MDBServerName { set; get; }

        /// <summary>
        /// 数据库端口
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public string MDBServerPort { set; get; }

        /// <summary>
        /// 数据的用户名
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public string MUserName { set; get; }

        /// <summary>
        /// 数据库密码
        /// </summary>
        [SugarColumn(IsOnlyIgnoreInsert = true)]
        public string MPassword { set; get; }

        public bool MIsDelete { set; get; }


        public bool MIsActive { set; get; }


    }
}
