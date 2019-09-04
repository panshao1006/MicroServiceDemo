using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model.User
{
    public class UserModel : BaseModel
    {
        public string MEmail { set; get; }

        /// <summary>
        /// 名
        /// </summary>
        public string MFirstName { set; get; }

        /// <summary>
        /// 姓
        /// </summary>
        public string MLastName { set; get; }


        public string MPassword { set; get; }
    }
}
