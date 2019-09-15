using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model
{
    /// <summary>
    /// 模块
    /// </summary>
    public class ModuleModel
    {
        public string MItemID { set; get; }

        public string MLinkUrl { set; get; }

        public string MName { set; get; }

        public bool MIsActive { set; get; }
    }
}
