using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.DTO.Author;

namespace User.Interface.DAL
{
    public interface IModuleRepository
    {
        List<ModuleDTO> GetModuleList(string userId, string orgId);
    }
}
