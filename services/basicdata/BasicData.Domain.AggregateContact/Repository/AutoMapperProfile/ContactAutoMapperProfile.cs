using AutoMapper;
using BasicData.Domain.AggregateContact.Entity;
using BasicData.Domain.AggregateContact.Repository.PO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.AutoMapperProfile
{
    public class ContactAutoMapperProfile : Profile
    {
        public ContactAutoMapperProfile()
        {
            RecognizeDestinationPrefixes("M");
            RecognizePrefixes("M");

            CreateMap<Contact, ContactPO>()
                .ForMember(po => po.MItemID, opts => opts.MapFrom(@do => @do.Id));

            CreateMap<ContactGroup ,ContactGroupPO>()
                .ForMember(po=>po.MItemID , opts=>opts.MapFrom(@do=>@do.Id))
                .ForMember(po => po.Languages, opts => opts.MapFrom(new ContactTypeLanguageResolver()))
                .ForMember(po=>po.MOrgID,opts=>opts.MapFrom(@do=>@do.OrganizationId)).ReverseMap()
                .ForMember(@do=>@do.OrganizationId , opts=>opts.MapFrom(po=>po.MOrgID))
                .ForMember(@do=>@do.Names , opts=>opts.MapFrom(new ContactGroupLanguageResolver()))
                .ForMember(@do => @do.Descriptiones, opts => opts.MapFrom(new ContactGroupLanguageResolver()))
                .AfterMap((src, dest) => dest.Names = dest.Names.Where(x=>x.Field=="Name").ToList())
                .AfterMap((src, dest) => dest.Descriptiones = dest.Descriptiones.Where(x => x.Field == "Desc").ToList());

            


        } 
    }
}
