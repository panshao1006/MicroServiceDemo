using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model
{
    public class OperationResult
    {
        public bool Success { set; get; }

        public List<string> Messages { set; get; }

        public string Message { set; get; }

        public string Id { set; get; }
    }
}
