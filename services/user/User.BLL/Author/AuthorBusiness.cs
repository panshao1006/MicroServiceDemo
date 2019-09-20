using System;
using System.Collections.Generic;
using System.Text;
using User.Model;

namespace User.BLL.Author
{
    /// <summary>
    /// 权限业务类
    /// </summary>
    public class AuthorBusiness
    {
        /// <summary>
        /// 用户，组织创建权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public OperationResult AddAuthor(string userId , string orgId)
        {
            OperationResult result = new OperationResult();

            return result;
        }
    }
}
