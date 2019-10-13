using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log.API.Model
{
    public class LogDAO
    {
        public string RequestId { set; get; }

        public string AppName { set; get; }

        public string Level { set; get; }

        public string Type { set; get; }

        public object Content { set; get; }

        public DateTime Date { set; get; }
    }
}
