using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Model
{
    public class OperationResult
    {
        public bool Success { set; get; }

        public string Message
        {
            get
            {
                if (Messages != null && Messages.Count > 0)
                {
                    return string.Join(",", Messages);
                }

                return null;
            }
        }

        public List<string> Messages { set; get; }

        /// <summary>
        /// 新增返回的ID
        /// </summary>
        public string ObjectId { set; get; }


        public OperationResult()
        {
            Messages = new List<string>();
        }

        public OperationResult(bool success)
        {
            Success = success;
            Messages = new List<string>();
        }
    }
}
