using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.Model.User;
using User.Model.ViewModel;

namespace User.Interface.BLL
{
    public interface IUserBusiness
    {
        UserModel GetUser(string email, string password);

        OperationResult InsertUser(UserModel user);
    }
}
