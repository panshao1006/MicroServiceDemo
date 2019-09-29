using Core.Common.FieldValidate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.DTO
{
    public class DetailedOrganizationDTO : OrganizationDTO
    {
        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime EnableDate { set; get; }

        /// <summary>
        /// 向导步骤
        /// </summary>
        public int WizardStep { set; get; }

        /// <summary>
        /// 固定资产启用日期
        /// </summary>
        public DateTime FAEnableDate { set; get; }

        /// <summary>
        /// 会计准则
        /// </summary>
        public int AccountingStandard { set; get; }

        /// <summary>
        /// 是否完成科目期初余额初始化
        /// </summary>
        public bool IsCompleteInitialBalance { set; get; }

        /// <summary>
        /// 本位币ID
        /// </summary>
        [FieldValidate(BaseDateType = BaseDataType.Currency)]
        public string BaseCurrencyId { set; get; }
    }
}
