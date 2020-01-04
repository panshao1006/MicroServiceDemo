using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Repository.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.AutoMapperProfile
{
    public class ContactAutoMapperProfile : Profile
    {
        public ContactAutoMapperProfile()
        {
            CreateMap<ContactPO, Contact>().ReverseMap()
                .ForMember(po => po.MItemID, opts => opts.MapFrom(@do => @do.Id));
               
        }
    }
}
