using Core.ORM.Attribute;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.Model
{
    [SugarTable("t_bas_organisation")]
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
        [SugarColumn(IsIgnore =true)]
        public string MCurrencyID { get; set; }

        /// <summary>
        /// 默认语言
        /// </summary>		
        public string MDefaulLocaleID { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string MCountryID { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string MStateID { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string MStateName { get; set; }
    

        public string MCityID { get; set; }


        public string MStreet { get; set; }


        public string MPostalNo { get; set; }

        /// <summary>
        /// 注册地址
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MRegAddress { get; set; }

        /// <summary>
        /// 纳税人类型
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MTaxPayer { get; set; }

        /// <summary>
        /// 税务登记证号
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MTaxNo { get; set; }

        /// <summary>
        /// 组织支持语言
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MSystemLanguage { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string[] MLanguage { get; set; }

        /// <summary>
        /// 时区
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string MSystemZone { get; set; }

    }
}
