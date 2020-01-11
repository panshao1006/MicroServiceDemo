using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.DTO.Contact;

namespace BasicData.Application.AutomMapperProfile
{
    public class ContactAutomapperResolver : IValueResolver<ContactDTO, Contact, Contact>
    {
        
        public Contact Resolve(ContactDTO source, Contact destination, Contact destMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
