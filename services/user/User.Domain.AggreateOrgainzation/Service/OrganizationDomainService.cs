using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.AggreateOrgainzation.Repository.PO;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Service
{
    public class OrganizationDomainService
    {
        private IRepository<RolePO> _roleRepository;
        private IRepository<RolePermissionRelationPO> _rolePermissionRelation;
        private IRepository<PermissionPO> _permissonRepository;
        private IRepository<OrganizationPO> _organizationRepository;


        public OrganizationDomainService(IRepository<RolePO> roleRepository ,
            IRepository<PermissionPO> permissonRepository,
            IRepository<RolePermissionRelationPO> rolePermissionRelation,
            IRepository<OrganizationPO> organizationRepository)
        {
            _roleRepository = roleRepository;
            _rolePermissionRelation = rolePermissionRelation;
            _permissonRepository = permissonRepository;
        }
    }
}
