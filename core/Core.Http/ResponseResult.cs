using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Http
{
    public class ResponseResult
    {
        public bool Success { set; get; }

        public string Message { set; get; }

        public object Data { set; get; }

        public string Code { set; get; }
    }
}
