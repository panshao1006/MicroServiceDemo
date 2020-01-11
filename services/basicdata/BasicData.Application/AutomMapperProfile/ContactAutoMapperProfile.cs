using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.DTO.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Application.AutomMapperProfile
{
    public class ContactAutoMapperProfile : Profile
    {
        public ContactAutoMapperProfile()
        {
            CreateMap<ContactDTO, Contact>()
                .ForMember(@do=> @do.Id , opts=>opts.MapFrom(dto=> dto.Id))
                .ForMember(@do => @do.ContactName, opts => opts.MapFrom(dto => dto.Name))
                .ForMember(@do=>@do.ContactNames , opts=>opts.MapFrom(dto=>dto.LanguageNames));

            CreateMap<ContactGroupDTO, ContactGroup>();
        }
    }
}
