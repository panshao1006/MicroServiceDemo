using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Repository.PO
{
    /// <summary>
    /// 用户激活信息
    /// </summary>
    public class UserActiveInfoPO : BasePO
    {
        public string MUserID { set; get; }

        public string MEmail { set; get; }

        public string MPhone { set; get; }

        public string MFirstName { set; get; }

        public string MLastName { set; get; }

        /// <summary>
        /// 邀请的组织，不是邀请未空
        /// </summary>
        public string MInvitationOrgID { set; get; }

        /// <summary>
        /// 邀请人邮箱
        /// </summary>
        public string MInvitationEmail { set; get; }

        /// <summary>
        /// 发送事件
        /// </summary>
        public DateTime MSendDate { set; get; }

        /// <summary>
        /// 连接类型 1 注册 2 邀请
        /// </summary>
        public int MLinkType { set; get; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime MExpireDate { set; get; }


        public UserPO User { set; get; }
    }
}
