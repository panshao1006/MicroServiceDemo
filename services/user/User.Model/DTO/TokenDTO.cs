using System;
using System.Collections.Generic;
using System.Text;

namespace User.Model.DTO
{
    public class TokenDTO
    {
        /// <summary>
        /// token值
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { set; get; }

        /// <summary>
        /// 组织ID
        /// </summary>
        public string OrganizationId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDateTime { set; get; }


        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime ExpireDateTime { set; get; }   
    }
}
