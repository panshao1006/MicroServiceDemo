using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model
{
    public class OperationResult
    {
        public bool Success { set; get; }

        public List<string> Messages { set; get; }

        public string Message
        {
            get
            {
                if(Messages!=null && Messages.Count > 0)
                {
                    return string.Join(",", Messages);
                }

                return null;
            }
        }

        public string Id { set; get; }

        public object Data { set; get; }


        public OperationResult()
        {
            Messages = new List<string>();
        }

        public OperationResult(bool success)
        {
            this.Success = success;
            Messages = new List<string>();
        }
    }
}
