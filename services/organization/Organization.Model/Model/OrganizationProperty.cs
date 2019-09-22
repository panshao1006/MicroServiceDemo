using Core.ORM.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.Model
{
    public class OrganizationProperty
    {
        public string MOrgId { set; get; }

        /// <summary>
        /// 是否是付费版
        /// </summary>
        public bool MIsPaid { get; set; }

        /// <summary>
        /// 初始化余额是否完成
        /// </summary>
        public bool MInitBalanceOver { set; get; }

        /// <summary>
        /// 固定资产启用日期
        /// </summary>
        public DateTime MFABeginDate { get; set; }


        /// <summary>
        /// 是否Beta测试组织
        /// </summary>
        public bool MIsBeta { get; set; }

        /// <summary>
        /// 是否为演示组织
        /// </summary>
        public bool MIsDemo { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime MExpiredDate { get; set; }

        /// <summary>
        /// 组织会计准则
        /// </summary>
        public string MAccountingStandard { get; set; }

        /// <summary>
        /// 启用期间（yyyy-MM）
        /// </summary>
        public string MConversionPeriod { get; set; }

        /// <summary>
        /// 初始化进度
        /// </summary>		
        public int MRegProgress { get; set; }


        /// <summary>
        /// 启用日期
        /// </summary>		
        public DateTime MConversionDate { get; set; }


        /// <summary>
        /// 订阅状态：已付费，已过期，试用期, 试用期满
        /// </summary>
        public int MSubscriptionStatus { get; set; }


        /// <summary>
        /// 是否已过期
        /// </summary>
        [ColumnName(false)]
        public bool MIsExpired
        {
            get
            {
                return MExpiredDate < DateTime.Now.AddDays(-1);
            }
        }
    }
}
