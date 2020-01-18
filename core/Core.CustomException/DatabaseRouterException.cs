using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CustomException
{
    /// <summary>
    /// 数据库路由异常
    /// </summary>
    public class DatabaseRouterException : CustomException
    {
        public DatabaseRouterException(string message) : base(message)
        {

        }
    }
}
