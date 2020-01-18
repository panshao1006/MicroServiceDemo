using AutoMapper;
using BasicData.Domain.AggregateEmailTemplate.Entity;
using BasicData.DTO.EmailTemplate;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Application.AutomMapperProfile
{
    public class CustomAutomapperProfile:Profile
    {
        public CustomAutomapperProfile()
        {
            CreateMap<EmailTemplate, EmailTemplateDTO>().ForMember(dto=>dto.Content , opts=>opts.MapFrom(x=>x.Content));
        }
    }
}
