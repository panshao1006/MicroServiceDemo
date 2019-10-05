using Core.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.BLL
{
    public class BaseBusiness
    {
        /// <summary>
        /// 获取用户ID
        /// </summary>
        /// <returns></returns>
        protected string GetCurrentUserId()
        {
           return TokenContext.CurrentContext.GetUserId();
        }
    }
}
