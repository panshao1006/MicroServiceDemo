using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Repository.PO;
using BasicData.Infrastructure;
using BasicData.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateContact.Service
{
    public class ContactDomainService
    {
        private IRepository<ContactPO> _reposiotry;

        private IMapper _mapper;

        public ContactDomainService(IRepository<ContactPO> repository , IMapper mapper)
        {
            _reposiotry = repository;
            _mapper = mapper;
        }

        public List<Contact> GetContacts()
        {
            var result = new List<Contact>();

            var contactPoes = _reposiotry.Query().AsNoTracking().ToList();

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
            var contactPO = _reposiotry.Query().AsNoTracking().FirstOrDefault(x=>x.MItemID == id);

            var contact = _mapper.Map<ContactPO, Contact>(contactPO);

            return contact;
        }

        /// <summary>
        /// 创建一个联系人
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public OperationResult Create(Contact contact)
        {
            OperationResult result = contact.Validate();

            if(result.Success == false)
            {
                return result;
            }

            var contactPO = _mapper.Map<Contact, ContactPO>(contact);

            _reposiotry.Add(contactPO);
            result.Success = _reposiotry.SaveChange() > 0;

            return result;
        }


    }
}
