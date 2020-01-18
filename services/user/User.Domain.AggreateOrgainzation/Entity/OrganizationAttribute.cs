using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure;

namespace User.Domain.AggreateOrgainzation.Entity
{
    /// <summary>
    /// 组织的常规信息
    /// </summary>
    public class OrganizationAttribute : BaseEntity
    {
        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { get; protected set; }

        /// <summary>
        /// 初始化向导步骤 1 创建向导 2创建完成税率 3 完成科目初始化 4完成科目余额初始化 5完成
        /// </summary>
        public int InitWizardIndex { get; protected set; }

        /// <summary>
        /// 本位币
        /// </summary>
        public string BaseCurrencyId { get; protected set; }

        /// <summary>
        /// 启用日期
        /// </summary>
        public DateTime BeginDate { get; protected set; }

        /// <summary>
        /// 固定资产启用日期
        /// </summary>
        public DateTime FABeginDate { get; protected set; }

        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime ExpiredDate { get; protected set; }

        /// <summary>
        /// 余额初始状态 0 未完成 1已完成
        /// </summary>
        public int InitBalanceStatus { get; protected set; }


        /// <summary>
        /// 组织版本 1 标准版 2记账版
        /// </summary>
        public int Version { set; get; }

        /// <summary>
        /// 组织类型 0 试用组织 1付费组织
        /// </summary>
        public int Type { get; protected set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="baseCurrencyId"></param>
        /// <returns></returns>
        public OperationResult Create(string organizationId , string baseCurrencyId)
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(organizationId))
            {
                result.Success = false;
                result.Messages.Add("组织Id不能为空");

                return result;
            }

            OrganizationId = organizationId;
            ExpiredDate = DateTime.Now.AddMonths(30);
            Type = 0;
            InitBalanceStatus = 0;
            InitWizardIndex = 1;
            BeginDate = DateTime.Now;
            BaseCurrencyId = baseCurrencyId;
            FABeginDate = DateTime.MinValue;

            result.Success = true;

            return result;
        }

        /// <summary>
        /// 更新向导步骤
        /// </summary>
        /// <param name="wizardIndex"></param>
        public OperationResult SetInitwizard(int wizardIndex)
        {
            OperationResult result = new OperationResult();

            if (InitWizardIndex == 5)
            {
                result.Messages.Add("组织已经完成了初始，不能重新设置向导步骤");
                result.Success = false;
                return result;
            }

            InitWizardIndex = wizardIndex;

            result.Success = true;

            return result;
        }
    }
}
