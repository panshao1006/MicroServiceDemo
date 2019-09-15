using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model
{
    public class MenuModel
    {
        /// <summary>
        /// 模块
        /// </summary>
        public List<ModuleModel> Modules { set; get; }


        /// <summary>
        /// 组织ID
        /// </summary>
        public string MOrgID { set; get; }
    }
}
