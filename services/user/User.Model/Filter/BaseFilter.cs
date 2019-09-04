using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Filter
{
    public class BaseFilter
    {
        public string Id { set; get; }

        /// <summary>
        /// 页数
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { set; get; }

    }
}
 