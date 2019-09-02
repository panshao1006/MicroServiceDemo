using System;
using System.Collections.Generic;
using System.Text;
using User.Interface.BLL;
using User.Interface.DAL;
using User.Model;
using User.Model.Model.User;
using User.Model.ViewModel;

namespace User.BLL.User
{
    public class UserBusiness: IUserBusiness
    {
        IUserRepository _userRepository;


        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 新增账号
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ResultModel Insert(UserRegisterViewModel user)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 根据用户名和密码获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserModel GetUser(string email , string password)
        {
            UserModel result = _userRepository.GetUser(email, password);

            return result;
        }
    }
}
