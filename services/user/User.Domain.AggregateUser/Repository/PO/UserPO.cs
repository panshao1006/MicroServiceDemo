using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Repository.PO
{
    public class UserPO : BasePO
    {
        /// <summary>
        /// 邮箱地址
        /// </summary>
        public string MEmailAddress { set; get; }

        public string MFirstName { set; get; }


        public string MLastName { set; get; }

        public string MPassword { set; get; }

        /// <summary>
        /// 用户的应用类型
        /// </summary>
        public string MAppID { set; get; }

        /// <summary>
        /// 是否通过未激活 1未激活 0已激活
        /// </summary>
        public int MIsTemp { set; get; }

        /// <summary>
        /// 激活信息
        /// </summary>
        public List<UserActiveInfoPO> UserActiveInfos { set; get; }
    }
}
