using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Repository.PO;
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

        public Contact GetContact(string id)
        {
            var contact = new Contact(_reposiotry , _mapper).Get(id);

            return contact;
        }


    }
}
