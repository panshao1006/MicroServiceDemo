using System;
using System.Collections.Generic;
using System.Text;
using User.Model.DAO.Author;

namespace User.Interface.DAL
{
    public interface IAuthorRepository
    {
        bool AddAuthor(UserGroupRelationDAO userGroupRelation, UserRoleRelationDAO userRoleRelation , List<RolePermisionRelationDAO> rolePermisionRelations, GroupRoleRealtionDAO groupRoleRealtion);
    }
}
