using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.Model.User;

namespace User.Interface.DAL
{
    public interface IUserRepository
    {
        UserModel GetUser(string eamil, string password);

        int InsertUser(UserModel user);
    }
}
