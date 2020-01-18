using System;
using System.Collections.Generic;
using System.Text;

namespace User.Infrastructure.Data
{
    public class BasePO
    {
        public string MItemID { set; get; }

        public bool MIsActive { set; get; }

        public bool MIsDelete { set; get; }

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
        public DateTime MModifyDate { set; get; }
    }
}
