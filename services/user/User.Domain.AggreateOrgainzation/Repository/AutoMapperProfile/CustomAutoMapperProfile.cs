using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggreateOrgainzation.Entity;
using User.Domain.AggreateOrgainzation.Repository.PO;

namespace User.Domain.AggreateOrgainzation.Repository.AutoMapperProfile
{
    public class CustomAutoMapperProfile : Profile
    {
        public CustomAutoMapperProfile()
        {
            RecognizePrefixes("M");
            RecognizeDestinationPrefixes("M");

            CreateMap<Organization, OrganizationPO>();

            CreateMap<Role, RolePO>();

            CreateMap<Permission, PermissionPO>();

            CreateMap<UserRoleRelation, UserRoleRelationPO>();

            CreateMap<RolePermissionRelation, RolePermissionRelationPO>();
        }
    }
}
