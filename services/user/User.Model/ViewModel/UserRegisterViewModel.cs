using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.ViewModel
{
    public class UserRegisterViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 电话号码
        /// </summary>
        public string Phone { set; get; }
    }
}
