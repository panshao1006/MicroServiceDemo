using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.PO
{
    public class ContactLanguagePO : BaseLanguagePO
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string MName { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string MDesc { set; get; }


        /// <summary>
        /// 主要联系人名
        /// </summary>
        public string MFirstName { set; get; }

        /// <summary>
        /// 主要联系姓
        /// </summary>
        public string MLastName { set; get; }

        /// <summary>
        /// 收件人
        /// </summary>
        public string MPAttention { set; get; }

        /// <summary>
        /// 街道
        /// </summary>
        public string MPStreet { set; get; }

        /// <summary>
        /// 地区
        /// </summary>
        public string MPRegion { set; get; }

        /// <summary>
        /// 法定地址收件人
        /// </summary>
        public string MRealAttention { set; get; }

        /// <summary>
        /// 法定地址街道
        /// </summary>
        public string MRealStreet { set; get; }

        /// <summary>
        /// 法定地址区域
        /// </summary>
        public string MRealRegion { set; get; }

        /// <summary>
        /// 银行账号名称
        /// </summary>
        public string MBankAccName { set; get; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string MBankName { set; get; }


        /// <summary>
        /// 导航属性
        /// </summary>
        public ContactPO Contact { set; get; }
    }
}
