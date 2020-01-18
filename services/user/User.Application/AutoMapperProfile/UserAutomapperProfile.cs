using AutoMapper;
using BasicData.Domain.AggregateEmailTemplate.Repository;
using User.Domain.AggregateUser.Entity;
using User.Domain.AggregateUser.Repository.PO;
using User.DTO;
using User.Infrastructure.Data;

namespace User.Application.AutoMapperProfile
{
    public class UserAutomapperProfile:Profile
    {
        protected IRepository<UserPO> _repository;

        protected IMapper _mapper;

        public UserAutomapperProfile()
        {
            RecognizePrefixes("M");
            RecognizeDestinationPrefixes("M");

            CreateMap<UserDTO, User.Domain.AggregateUser.Entity.User>();
            CreateMap<ActiveInfoDTO, UserActiveInfo>()
                .ReverseMap()
                .ForMember(dto => dto.UserId, opts => opts.MapFrom(x=>x.UserId));

            CreateMap<EmailTemplateDTO, EmailTemplate>()
               .ForMember(@do => @do.Content, opts => opts.MapFrom(x => x.Content))
               .ForMember(@do => @do.Contents, opts => opts.Ignore());

        }


    }
}
