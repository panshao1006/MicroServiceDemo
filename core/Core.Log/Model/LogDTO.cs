using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Log.Model
{
    public class LogDTO
    {
        public string Id {
            get
            {
                return GuidUtility.GetGuid();
            }
        }


        public string RequestId { set; get; }

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { set; get; }

        /// <summary>
        /// 日志类型
        /// </summary>
        public LogType Type { set; get; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public LogLevelType Level { set; get; }

        /// <summary>
        /// 日志内容
        /// </summary>
        public object Content { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime
        {
            get
            {
                return DateTime.Now;
            }
        }


    }
}
