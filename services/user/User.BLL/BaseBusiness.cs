using Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.BLL
{
    public class BaseBusiness
    {
        public string GetToken()
        {
            return TokenContext.CurrentContext.GetToken();
        }
    }
}
