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
        /// 往来科目Id
        /// </summary>
        public string AccountId { set; get; }

        /// <summary>
        /// 组织Id
        /// </summary>
        public string OrganizationId { set; get; }

        /// <summary>
        /// 联系人基本信息
        /// </summary>
        public ContactBaseInfo ContactInfo { set; get; }

        /// <summary>
        /// 联系人财务信息
        /// </summary>
        public ContactFinanceInfo FinanceInfo { set; get; }

        private IRepository<ContactPO> _repository;

        private IMapper _mapper;


        public Contact(IRepository<ContactPO> repository , IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }


        /// <summary>
        /// 插入联系人
        /// </summary>
        /// <returns></returns>
        public OperationResult Insert()
        {
            OperationResult result = Validate();

            if (!result.Success)
            {
                return result;
            }

            var contactPO = _mapper.Map<Contact, ContactPO>(this);

            _repository.Add(contactPO);

            int effRow = _repository.SaveChange();

            result.Success = effRow > 0;

            return result;
        }

        /// <summary>
        /// 联系人信息的校验
        /// </summary>
        /// <returns></returns>
        private OperationResult Validate()
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
        /// 新增
        /// </summary>
        /// <returns></returns>
        public OperationResult Create()
        {
            OperationResult result = new OperationResult();

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

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact Get(string id)
        {
            var contactPO = _repository.Query().AsNoTracking().Where(x => x.MItemID == id).FirstOrDefault();

            return _mapper.Map<ContactPO, Contact>(contactPO);
        }

    }
}
