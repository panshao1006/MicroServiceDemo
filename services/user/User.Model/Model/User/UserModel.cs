using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.Model.User
{
    public class UserModel : BaseModel
    {
        /// <summary>
        /// 名
        /// </summary>
        public string MFirstName { set; get; }

        /// <summary>
        /// 性
        /// </summary>
        public string MLastName { set; get; }
    }
}
