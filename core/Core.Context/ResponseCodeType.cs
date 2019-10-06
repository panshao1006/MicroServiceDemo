using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Context
{
    public enum ResponseCodeType
    {
        /// <summary>
        /// header中没有token参数
        /// </summary>
        HeaderTokenIsEmpty=100010,

        /// <summary>
        /// 无法找到Token
        /// </summary>
        NotFindTokenInfo=100020,
    }
}
