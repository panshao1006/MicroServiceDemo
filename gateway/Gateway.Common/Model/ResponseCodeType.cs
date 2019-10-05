using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Common.Model
{
    public enum ResponseCodeType
    {
        /// <summary>
        /// 没有登录
        /// </summary>
        NotLogin=100010,

        /// <summary>
        /// Token已经过期
        /// </summary>
        TokenExpire=100020,

        /// <summary>
        /// 没有配置token的请求地址
        /// </summary>
        NotConfigValidateTokenURL=100030,

        /// <summary>
        /// token为空
        /// </summary>
        TokenIsEmpty=100040
    }
}
