using System;
using System.Collections.Generic;
using System.Text;
using User.Model;

namespace User.Interface.BLL
{
    public interface ISessionBusiness
    {
        /// <summary>
        /// 更改组织
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        OperationResult ChangeOrganization(string organizationId);
    }
}
