using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.Model
{
    public class OrganizationModel: BaseModel
    {
        /// <summary>
        /// MRegionID
        /// </summary>		
        public string MRegionID { get; set; }


        /// <summary>
        /// 创建组织的用户ID
        /// </summary>		
        public string MMasterID { get; set; }

        /// <summary>
        /// 法定名称
        /// </summary>		
        public string MLegalTradingName { get; set; }

        /// <summary>
        /// 组织版本
        /// </summary>
        public int MVersionID { get; set; }

        /// <summary>
        /// 组织类型
        /// </summary>		
        public string MOrgTypeID { get; set; }

        /// <summary>
        /// 组织所属行业
        /// </summary>		
        public string MOrgBusiness { get; set; }

        /// <summary>
        /// 组织本位币
        /// </summary>
        public string MCurrencyID { get; set; }

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
        /// 默认语言
        /// </summary>		
        public string MDefaulLocaleID { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string MCountryID { get; set; }

        public string MCountryName { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string MStateID { get; set; }

        
        public string MStateName { get; set; }
    

        public string MCityID { get; set; }


        public string MStreet { get; set; }


        public string MPostalNo { get; set; }

        /// <summary>
        /// 是否是付费版
        /// </summary>
        public bool MIsPaid { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        public string MRegAddress { get; set; }

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
        /// 纳税人类型
        /// </summary>
        public string MTaxPayer { get; set; }

        /// <summary>
        /// 税务登记证号
        /// </summary>
        public string MTaxNo { get; set; }

        /// <summary>
        /// 组织支持语言
        /// </summary>
        public string MSystemLanguage { get; set; }

        public string[] MLanguage { get; set; }

        /// <summary>
        /// 是否为演示组织
        /// </summary>
        public bool MIsDemo { get; set; }

        /// <summary>
        /// 订阅状态：已付费，已过期，试用期, 试用期满
        /// </summary>
        public int MSubscriptionStatus { get; set; }

        /// <summary>
        /// 时区
        /// </summary>
        public string MSystemZone { get; set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime MExpiredDate { get; set; }

        /// <summary>
        /// 是否已过期
        /// </summary>
        public bool MIsExpired
        {
            get
            {
                return MExpiredDate < DateTime.Now.AddDays(-1);
            }
        }
    }
}
