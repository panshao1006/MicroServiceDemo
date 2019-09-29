using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.Filter
{
    public class BaseFilter
    {
        public int PageSize { set; get; }

        public int PageIndex { set; get; }
    }
}
