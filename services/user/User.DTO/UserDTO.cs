using System;

namespace User.DTO
{
    public class UserDTO
    {
        public string Id { set; get; }

        public string EmailAddress { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        public string Password { set; get; }

        /// <summary>
        /// 确定密码
        /// </summary>
        public string ConfimPassword { set; get; }


        public string LangId { set; get; }

        /// <summary>
        /// 激活连接Id
        /// </summary>
        public string ActiveInfoId { set; get; }
    }
}
