using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model
{
    public class OperationResult
    {
        public bool Success { set; get; }

        public string Message { set; get; }

        public List<string> Messages { set; get; }

        /// <summary>
        /// 新增返回的ID
        /// </summary>
        public string ObjectId { set; get; }


        public OperationResult()
        {
            Messages = new List<string>();
        }
    }
}
