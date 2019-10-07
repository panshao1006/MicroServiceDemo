using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.DTO;

namespace User.Interface.BLL
{
    public interface IMenuBusiness
    {
        OperationResult GetMenus(string userId , string orgnaizationId);
    }
}
