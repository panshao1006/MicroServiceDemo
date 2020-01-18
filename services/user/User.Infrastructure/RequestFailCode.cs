using System;
using System.Collections.Generic;
using System.Text;

namespace User.Infrastructure
{
    public enum RequestFailCode
    {
        /// <summary>
        /// 用户名或密码不正确
        /// </summary>
        PasswordError= 100001,

        /// <summary>
        /// 缺少参数
        /// </summary>
        ParametersMissing=10002,
    }
}
