using System;
using System.Collections.Generic;
using System.Text;
using User.Model.DTO.Author;

namespace User.Model.DTO
{
    public class MenuDTO
    {
        /// <summary>
        /// 模块
        /// </summary>
        public List<ModuleDTO> Modules { set; get; }


        /// <summary>
        /// 组织ID
        /// </summary>
        public string MOrgID { set; get; }
    }
}
