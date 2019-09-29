using Organization.Model.DAO;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model
{
    [SugarTable("t_bas_organisation")]
    public class OrganizationDAO : BaseDAO
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
        /// 显示名称
        /// </summary>
        public string MName { set; get; }

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


        public string MCityID { get; set; }


        public string MStreet { get; set; }


        public string MPostalNo { get; set; }

        
    }
}
