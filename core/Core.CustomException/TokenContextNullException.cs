using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CustomException
{
    /// <summary>
    /// Token上下文为空
    /// </summary>
    public class TokenContextNullException:CustomException
    {
        public TokenContextNullException(string message) : base(message)
        {

        }
    }
}
