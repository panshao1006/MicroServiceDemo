using BasicData.Domain.AggregateContact.Repository.PO;
using BasicData.Infrastructure;
using BasicData.Infrastructure.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;
using AutoMapper;

namespace BasicData.Domain.AggregateContact.Entity
{
    /// <summary>
    /// 联系人实体聚合根
    /// </summary>
    public class Contact : AggregateRoot
    {
        /// <summary>
        /// 联系人名称
        /// </summary>
        public string ContactName { set; get; }

        /// <summary>
        /// 多语言字段
        /// </summary>
        public List<LanguageValueObject> ContactNames { set; get; }

        /// <summary>
        /// 往来科目Id
        /// </summary>
        public string AccountId { set; get; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { set; get; }

        /// <summary>
        /// 联系人类型，用逗号隔开
        /// </summary>
        public string ContactTypeIds { set; get; }


        public List<ContactGroup> ContactTypes { set; get; }

        /// <summary>
        /// 联系人基本信息
        /// </summary>
        public ContactBaseInfo ContactInfo { set; get; }

        /// <summary>
        /// 联系人财务信息
        /// </summary>
        public ContactFinanceInfo FinanceInfo { set; get; }

        public Contact()
        {
        }


        /// <summary>
        /// 新增联系人
        /// </summary>
        /// <returns></returns>
        public Contact Create()
        {
            this.Id = NewId;
            
            return this;
        }

        /// <summary>
        /// 联系人信息的校验
        /// </summary>
        /// <returns></returns>
        public OperationResult Validate()
        {
            OperationResult result = new OperationResult();

            if (string.IsNullOrWhiteSpace(OrganizationId))
            {
                result.Messages.Add("联系人组织不能为空");
            }

            if (string.IsNullOrWhiteSpace(ContactName))
            {
                result.Messages.Add("联系人的名称不能为空");
            }

            result.Success = result.Messages.Count == 0;

            return result;
        }

        /// <summary>
        /// 更新时的校验
        /// </summary>
        /// <returns></returns>
        public OperationResult ValidateUpdate()
        {
            var result = Validate();

            if (string.IsNullOrWhiteSpace(Id))
            {
                result.Messages.Add("联系人没有传入Id");
            }

            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public OperationResult Update()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public OperationResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}
