using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BasicData.Infrastructure
{
    /// <summary>
    /// 操作结果
    /// </summary>
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

        public bool Success { set; get; }


        public OperationResult()
        {
            Messages = new List<string>();
        }
    }
}
