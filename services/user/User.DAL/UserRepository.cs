using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.DAL;
using User.Model.Model.User;

namespace User.DAL
{
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="eamil"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserModel GetUser(string eamil , string password)
        {
            return new UserModel();
        }
    }
}
