using System;
using System.Collections.Generic;
using System.Text;
using User.Model;

namespace User.Interface.DAL
{
    public interface IModuleRepository
    {
        List<ModuleModel> GetModuleList(string userId, string orgId);
    }
}
