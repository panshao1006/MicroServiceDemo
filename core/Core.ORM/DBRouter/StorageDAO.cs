using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ORM.DBRouter
{
    [SugarTable("t_sys_storage")]
    public class StorageDAO
    {
        [SugarColumn(IsPrimaryKey =true)]
        public string MItemID { set; get; }

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

        /// <summary>
        /// 数据库已经存在的组织数
        /// </summary>
        public int MOrgCount { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public string MIsDelete { set; get; }
    }
}
