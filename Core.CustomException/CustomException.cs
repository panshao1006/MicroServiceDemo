using System;

namespace Core.CustomException
{
    public class CustomException : ApplicationException
    {
        protected string _message { set; get; }

        public CustomException()
        {

        }

        public CustomException(string message):base(message)
        {
            this._message = message;
        }
    }
}
