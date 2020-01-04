using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.Model
{
    public class LogDAO
    {
        public string Id { set; get; }

        public string AppName { set; get; }

        public string Type { set; get; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public string Level { set; get; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { set; get; }
    }
}
