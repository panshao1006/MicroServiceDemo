using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Repository.PO;
using BasicData.Infrastructure;
using BasicData.Infrastructure.Data;
using Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateContact.Service
{
    public class ContactDomainService
    {
        private IRepository<ContactPO> _contactReposiotry;

        private IRepository<ContactGroupPO> _contactGroupRepository;

        private IMapper _mapper;

        public ContactDomainService(IRepository<ContactPO> contactReposiotry, 
            IRepository<ContactGroupPO> contactGroupRepository,
            IMapper mapper)
        {
            _contactReposiotry = contactReposiotry;
            _contactGroupRepository = contactGroupRepository;
            _mapper = mapper;
        }

        #region 联系人
        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <returns></returns>
        public List<Contact> GetContacts()
        {
            var result = new List<Contact>();

            var contactPoes = _contactReposiotry.Query().AsNoTracking().ToList();

            if(contactPoes!=null && contactPoes.Count > 0)
            {
                result.AddRange(_mapper.Map<List<Contact>>(contactPoes));
            }

            return result;
        }

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contact GetContact(string id)
        {
            var contactPO = _contactReposiotry.Query().AsNoTracking().FirstOrDefault(x=>x.MItemID == id);

            var contact = _mapper.Map<ContactPO, Contact>(contactPO);

            return contact;
        }

        /// <summary>
        /// 创建一个联系人
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public OperationResult CreateContact(Contact contact)
        {
            OperationResult result = contact.Validate();

            if(result.Success == false)
            {
                return result;
            }

            var contactPO = _mapper.Map<Contact, ContactPO>(contact);

            _contactReposiotry.Add(contactPO);
            result.Success = _contactReposiotry.SaveChange() > 0;

            return result;
        }
        #endregion

        #region 联系人分组
        /// <summary>
        /// 创建一个联系人类型
        /// </summary>
        /// <param name="contactType"></param>
        /// <returns></returns>
        public OperationResult CreateContactGroup(ContactGroup contactGroup)
        {
            OperationResult result = contactGroup.Validate();

            contactGroup.CreateContactGroup();

            if (!result.Success)
            {
                return result;
            }

            var contactGroupPO = _mapper.Map<ContactGroupPO>(contactGroup);

            _contactGroupRepository.Add(contactGroupPO);

            result.Success = _contactGroupRepository.SaveChange() > 0;

            return result;
        }

        /// <summary>
        /// 查询分组
        /// </summary>
        /// <returns></returns>
        public List<ContactGroup> GetContactGroups()
        {
            var contactGroupPOs = _contactGroupRepository.Query().Include(x=>x.Languages).Where(x=>x.MOrgID == TokenContext.CurrentContext.GetOrganizationId() || x.MOrgID=="0").AsNoTracking().ToList();

            var result = _mapper.Map<List<ContactGroup>>(contactGroupPOs);

            return result;
        }


        #endregion


    }
}
