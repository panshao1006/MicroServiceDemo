using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Common.Model
{
    public class ResponseResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { set; get; }

        public object Data { set; get; }

        public string Message { set; get; }

        public string Code { set; get; }
    }
}
