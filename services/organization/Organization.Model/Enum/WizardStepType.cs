using System;
using System.Collections.Generic;
using System.Text;

namespace Organization.Model.Enum
{
    public enum WizardStepType
    {
        /// <summary>
        /// 创建
        /// </summary>
        Created=1,

        /// <summary>
        /// 财务设置
        /// </summary>
        FinancialSetup,

        /// <summary>
        /// 已完成
        /// </summary>
        Completed=15
    }
}
