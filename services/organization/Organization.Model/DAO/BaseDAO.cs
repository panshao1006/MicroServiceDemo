using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.DAO
{
    public class BaseDAO
    {
        /// <summary>
        /// 主键id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public string MItemID { set; get; }


        /// <summary>
        /// 是否删除
        /// </summary>
        public bool MIsDelete { set; get; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public bool MIsActive { set; get; }
    }
}
