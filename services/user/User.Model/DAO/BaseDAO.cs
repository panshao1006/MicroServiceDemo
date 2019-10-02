using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DAO
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
        public string MIsDelete { set; get; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public string MIsActive { set; get; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string MCreatorID { set; get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime MCreateDate { set; get; }

        /// <summary>
        /// 修改者
        /// </summary>
        public string MModifierID { set; get; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public string MModifyDate { set; get; }
    }
}
