using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.DTO
{
    /// <summary>
    /// 过了条件
    /// </summary>
    public class BaseFilterDTO
    {
        /// <summary>
        /// 是否允许查找所有，默认为false
        /// </summary>
        public bool IsCanFindAll { set; get; }


        public int PageSize{set;get;}

        public int PageIndex { set; get; }
    }
}
