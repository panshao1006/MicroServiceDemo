using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model
{
    /// <summary>
    /// DTO基类
    /// </summary>
    public class BaseModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public string MItemID { set; get; }

        /// <summary>
        /// 名称
        /// </summary>
        public string MName { set; get; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public string MIsDelete { set; get; }

        /// <summary>
        /// 是否激活
        /// </summary>
        public string MIsActive { set; get; }
    }
}
