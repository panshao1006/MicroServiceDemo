using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.AggregateUser.Entity
{
    public class UserActiveInfo : BaseEntity
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { set; get; }

        public string Email { set; get; }

        public string Phone { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }

        /// <summary>
        /// 邀请的组织，不是邀请未空
        /// </summary>
        public string InvitationOrgID { set; get; }

        /// <summary>
        /// 邀请人邮箱
        /// </summary>
        public string InvitationEmail { set; get; }

        /// <summary>
        /// 发送事件
        /// </summary>
        public DateTime SendDate { set; get; }

        /// <summary>
        /// 连接类型 1 注册 2 邀请
        /// </summary>
        public int LinkType { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime ExpireDate { set; get; }

        /// <summary>
        /// 邮件内容
        /// </summary>
        public EmailTemplate EmailTemplate { set; get; }
    }
}
