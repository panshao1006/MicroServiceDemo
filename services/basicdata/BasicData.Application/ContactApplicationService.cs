using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Service;
using BasicData.DTO.Account;
using BasicData.DTO.Contact;
using BasicData.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicData.Application
{
    public class ContactApplicationService
    {
        private IMapper _mapper;

        private ContactDomainService _contactDomainService;

        private AccountApplicationService _accountApplicationService;

        public ContactApplicationService(IMapper mapper ,
            ContactDomainService contactDomainService , 
            AccountApplicationService accountApplicationService)
        {
            _contactDomainService = contactDomainService;
            _accountApplicationService = accountApplicationService;
            _mapper = mapper;
        }

        #region 联系人

        /// <summary>
        /// 获取联系人
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public List<ContactDTO> GetContacts(ContactFilterDTO filter)
        {
            var contacts = _contactDomainService.GetContacts();

            var result = _mapper.Map<List<ContactDTO>>(contacts);

            //需要调用科目的应用服务，进行科目的赋值
            var accounts = _accountApplicationService.GetAccounts();

            var accountDtos = _mapper.Map<List<AccountDTO>>(accounts);

            if(accountDtos != null && accountDtos.Count > 0)
            {
                result.ForEach(x =>
                {
                    var matchAccount = accountDtos.FirstOrDefault(y => y.Id == x.AccountId);

                    x.Account = matchAccount;
                });
            }

            return result;
        }

        /// <summary>
        /// 获取一个联系人
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactDTO GetContact(string id)
        {
            var contact = _contactDomainService.GetContact(id);

            var result = _mapper.Map<Contact, ContactDTO>(contact);

            if(result == null)
            {
                return result;
            }

            //需要调用科目的应用服务，进行科目的赋值
            var accounts = _accountApplicationService.GetAccounts();

            var accountDtos = _mapper.Map<List<AccountDTO>>(accounts);

            if (accountDtos != null && accountDtos.Count > 0)
            {
                var matchAccount = accountDtos.First(y => y.Id == result.AccountId);

                result.Account = matchAccount;
            }

            return result;
        }

        /// <summary>
        /// 新增一个联系人
        /// </summary>
        /// <param name="contactDTO"></param>
        /// <returns></returns>
        public OperationResult CreateContact(ContactDTO contactDTO)
        {
            var contact = _mapper.Map<ContactDTO, Contact>(contactDTO);

            var result = contact.Validate();

            if (!result.Success)
            {
                return result;
            }

            result = _contactDomainService.CreateContact(contact);

            return result;
        }

        #endregion

        #region 联系人分组

        /// <summary>
        /// 新建联系人分组
        /// </summary>
        /// <param name="contactGroupDTO"></param>
        /// <returns></returns>
        public OperationResult CreateContactGroup(ContactGroupDTO contactGroupDTO)
        {
            var contactGroup = _mapper.Map<ContactGroup>(contactGroupDTO);

            var result = _contactDomainService.CreateContactGroup(contactGroup);

            return result;
        }

        /// <summary>
        /// 查询联系人分组
        /// </summary>
        /// <returns></returns>
        public List<ContactGroupDTO> GetContactGroups()
        {
            var contactGroups = _contactDomainService.GetContactGroups();

            var result = _mapper.Map<List<ContactGroupDTO>>(contactGroups);

            return result;
        }

        #endregion
    }
}
