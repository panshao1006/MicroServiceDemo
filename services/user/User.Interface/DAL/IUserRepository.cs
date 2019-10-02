using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.DAO.User;
using User.Model.Filter;

namespace User.Interface.DAL
{
    public interface IUserRepository
    {
        UserDAO GetUser(UserFilter filter);

        int InsertUser(UserDAO user);
    }
}
