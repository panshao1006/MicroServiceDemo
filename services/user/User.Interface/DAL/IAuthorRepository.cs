using System;
using System.Collections.Generic;
using System.Text;
using User.Model.Model.Auth;

namespace User.Interface.DAL
{
    public interface IAuthorRepository
    {
        bool AddAuthor(UserGroupRelationModel userGroupRelation, UserRoleRelationModel userRoleRelation);
    }
}
