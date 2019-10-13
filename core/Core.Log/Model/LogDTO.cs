using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Log.Model
{
    public class LogDTO
    {
        public string RequestId { set; get; }

        public string AppName { set; get; }

        public LogLevelType Level { set; get; }

        public LogType Type { set; get; }

        public object Content { set; get; }

        public DateTime Date { get { return DateTime.UtcNow; } }
    }
}
