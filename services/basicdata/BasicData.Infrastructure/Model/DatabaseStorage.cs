using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BasicData.Infrastructure.Model
{
    public class DatabaseStorage
    {
        [Key]
        public string MItemID { set; get; }


        public string MBDName { set; get; }

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
        public bool MIsDelete { set; get; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        //public bool MIsActive { set; get; }

        /// <summary>
        /// 导航属性
        /// </summary>
        public List<OrganiztionStorageRelation> StorageRelations { set; get; }
    }

    /// <summary>
    /// 组织和数据库的对应关系
    /// </summary>
    public class OrganiztionStorageRelation
    {
        [Key]
        public string MItemID { set; get; }
        
        
        public string MOrgID { set; get; }

        /// <summary>
        /// 外键
        /// </summary>
        public string MStorageID { set; get; }

        /// <summary>
        /// 组织和数据库的对应关系
        /// </summary>
        public DatabaseStorage DatabaseStorage { set; get; }
    }
}
