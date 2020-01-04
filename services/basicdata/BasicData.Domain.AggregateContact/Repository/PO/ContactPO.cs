using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.PO
{
    public class ContactPO : BasePO
    {
        /// <summary>
        /// 往来科目ID
        /// </summary>
        public string MAccountID { set; get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string MEmail { set; get; }

        /// <summary>
        /// 通信国家ID
        /// </summary>
        public string MPCountryID { set; get; }


        /// <summary>
        /// 通信城市ID
        /// </summary>
        public string MPCityID { set; get; }

        /// <summary>
        /// 通信邮编
        /// </summary>
        public string MPPostalNo { set; get; }

        /// <summary>
        /// 法定国家ID
        /// </summary>
        public string MRealCountryID { set; get; }

        /// <summary>
        /// 法定城市ID
        /// </summary>
        public string MRealCityID { set; get; }

        /// <summary>
        /// 法定邮编
        /// </summary>
        public string MRealPostalNo { set; get; }

        /// <summary>
        /// 电话
        /// </summary>
        public string MPhone { set; get; }

        /// <summary>
        /// 传真
        /// </summary>
        public string MFax { set; get; }

    }
}
