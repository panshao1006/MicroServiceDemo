using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CustomException
{
    /// <summary>
    /// 请求数据失败
    /// </summary>
    public class RequestDataExcepiton:CustomException
    {
        public RequestDataExcepiton(string message) : base(message)
        {

        }
    }
}
