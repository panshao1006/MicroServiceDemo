using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.Model
{
    public class LogDTO
    {
        public string RequestId { set; get; }

        public string AppName { set; get; }

        public LogLevelType Level { set; get; }

        public LogType Type { set; get; }

        public object Content { set; get; }

        public DateTime Date { set; get; }


        public LogDAO Convert()
        {
            LogDAO dao = new LogDAO()
            {
                RequestId = RequestId,
                AppName = AppName,
                Level = Enum.GetName(typeof(LogLevelType), Level),
                Type = Enum.GetName(typeof(LogType), Type),
                Content = Content,
                Date = Date
            };


            return dao;
        }
    }
}
