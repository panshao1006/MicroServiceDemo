using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggregateUser.Entity;
using User.Domain.AggregateUser.Repository.PO;

namespace User.Domain.AggregateUser.Repository.AutomapperProfile
{
    public class UserAutomapperProfile : Profile
    {
        public UserAutomapperProfile()
        {
            RecognizePrefixes("M");
            RecognizeDestinationPrefixes("M");

            CreateMap<UserPO, User.Domain.AggregateUser.Entity.User>()
                .ForMember(@do => @do.Id, opts => opts.MapFrom(po => po.MItemID))
                .ForMember(@do => @do.Status, opts => opts.MapFrom(po => po.MIsTemp))
                .ForMember(@do => @do.EmailAddress, opts => opts.MapFrom(po => po.MEmailAddress))
                .ReverseMap()
                .ForMember(po=>po.MIsTemp , opts=>opts.MapFrom(@do=>@do.Status))
                .ForMember(po=>po.UserActiveInfos , opts=>opts.MapFrom(new DoUserActiveInfoResolver()));

            CreateMap<UserActiveInfoPO, UserActiveInfo>()
                .ForMember(@do => @do.Id, opts => opts.MapFrom(po => po.MItemID));
        }
    }
}
