using System;
using System.Collections.Generic;
using System.Text;

namespace User.DTO
{
    public class TokenDTO
    {
        public string TokenId { set; get; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { set; get; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { set; get; }

        /// <summary>
        /// 多语言Id 
        /// </summary>
        public string LangId { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpiredDate { set; get; }

        /// <summary>
        /// 拥有刷新的TokenId
        /// </summary>
        public string RefreshTokenId { set; get; }
    }
}
