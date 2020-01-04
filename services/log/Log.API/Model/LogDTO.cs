using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.Model
{
    public class LogDTO
    {
        public string Id { set; get; }

        public string AppName { set; get; }

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
        public DateTime CreateDateTime {set;get;}


        public LogDAO Convert()
        {
            LogDAO dao = new LogDAO()
            {
                Id = Id,
                AppName = AppName,
                Type = Enum.GetName(typeof(LogType) , Type),
                Level = Enum.GetName(typeof(LogLevelType), Level),
                Content = Content != null ? JsonConvert.SerializeObject(Content) : null,
                CreateDateTime = CreateDateTime
            };

            return dao;
        }
    }
}
