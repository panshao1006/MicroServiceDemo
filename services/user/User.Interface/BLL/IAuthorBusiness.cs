using System;
using System.Collections.Generic;
using System.Text;
using User.Model;

namespace User.Interface.BLL
{
    public interface IAuthorBusiness
    {
        OperationResult CreateAdminAuthor(string userId, string orgId);
    }
}
