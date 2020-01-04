using AutoMapper;
using BasicData.Domain.AggregateAccount.Entity;
using BasicData.Domain.AggregateAccount.Reposiotry.PO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateAccount.Reposiotry
{
    public class AccountAutoMapperProfile : Profile
    {
        public AccountAutoMapperProfile()
        {
            CreateMap<AccountPO, Account>().ReverseMap()
                .ForMember(po => po.MItemID, opts => opts.MapFrom(@do => @do.Id));
        }
    }
}
