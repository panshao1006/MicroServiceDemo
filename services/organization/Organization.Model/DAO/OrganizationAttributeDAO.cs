using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.DAO
{
    [SugarTable("t_bas_organizationattribute")]
    public class OrganizationAttributeDAO : BaseDAO
    {
        public string MOrgID { set; get; }

        /// <summary>
        /// 本位币
        /// </summary>
        public string MBaseCurrencyID { set; get; }

        /// <summary>
        /// 向导步骤
        /// </summary>
        public int MRegProgress { set; get; }

        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime MConversionDate { set; get; }

        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime MExpiredDate { set; get; }

        /// <summary>
        /// 固定资产启用日期
        /// </summary>
        public DateTime MFABeginDate { set; get; }

        /// <summary>
        /// 是否完成初始化
        /// </summary>
        public bool MInitBalanceOver { set; get; }
    }
}
