using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.ViewModel
{
    /// <summary>
    /// 账号登录模型
    /// </summary>
    public class UserLoginViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { set; get; }


        public string LangId { set; get; }
     }
}
