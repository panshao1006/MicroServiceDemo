using AutoMapper;
using BasicData.Domain.AggregateEmailTemplate.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Repository.AutoMapperProfile
{
    public class CustomAutomapperProfile : Profile
    {
        public CustomAutomapperProfile()
        {
            RecognizePrefixes("M");
            RecognizeDestinationPrefixes("M");

            CreateMap<EmailTemplatePO, EmailTemplate>()
                .ForMember(@do=>@do.Id , opts=>opts.MapFrom(x=>x.MItemID))
                .ForMember(@do=>@do.Type , opts=>opts.MapFrom(x=>x.MType))
                .ForMember(@do=>@do.Contents , opts=>opts.MapFrom(new DoLanguageResolver()));
        }
    }
}
