using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Common
{
    public static class ReponseJson
    {
        public static object Json(object data)
        {
            return new { Success = true, Data = data, Message = "" };
        }
    }
}
