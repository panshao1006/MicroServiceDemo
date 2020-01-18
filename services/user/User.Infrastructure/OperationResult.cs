using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Infrastructure
{
    public class OperationResult
    {

        public string Message
        {
            get
            {
                if (Messages.Count > 0) { return string.Join(",", Messages); }
                return null;
            }
        }

        [JsonIgnore]
        public List<string> Messages { set; get; }

        public object Data { set; get; }

        public bool Success { set; get; }

        public string Code { set; get; }


        public OperationResult()
        {
            Messages = new List<string>();
        }
    }
}
