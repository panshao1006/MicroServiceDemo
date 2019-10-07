using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.DTO.Author;

namespace User.Interface.DAL
{
    public interface IMenuRepository
    {
        List<ModuleDTO> GetModules(string userId, string organizationId);
    }
}
