using System;
using System.Collections.Generic;
using System.Text;
using User.Model;
using User.Model.Model;
using User.Model.Model.User;
using User.Model.ViewModel;

namespace User.Interface.BLL
{
    public interface IUserBusiness
    {
        UserModel GetUser(string email, string password);

        OperationResult InsertUser(UserModel user);

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        OperationResult Login(string email, string password);

        /// <summary>
        /// 校验token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        OperationResult CheckToken(string token);


        MenuModel GetUserMenu(string userId, string orgId);

        /// <summary>
        /// 获取一个token
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserViewModel GetUser(string token);
    }
}
