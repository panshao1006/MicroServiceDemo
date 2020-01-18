using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Data;

namespace User.Domain.AggreateOrgainzation.Repository.PO
{
    public class CustomModelBuilder : ICustomModelBuilder
    {
        public void Builder(ModelBuilder modelBuilder)
        {
            var organizationTypeBuilder = modelBuilder.Entity<OrganizationPO>();
            organizationTypeBuilder.ToTable("t_bas_organisation").HasKey(x => x.MItemID);
            organizationTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            organizationTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);

            var organizationAttributeTypeBuilder = modelBuilder.Entity<OrganizationAttributePO>();
            organizationAttributeTypeBuilder.ToTable("t_bas_organizationattribute").HasKey(x => x.MItemID);
            organizationAttributeTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            organizationAttributeTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
            organizationAttributeTypeBuilder.HasOne(x => x.Organization).WithOne().HasForeignKey<OrganizationAttributePO>(x => x.MOrgID);

            var roleModelTypeBuilder = modelBuilder.Entity<RolePO>();
            
            roleModelTypeBuilder.ToTable("t_sec_role").HasKey(x=>x.MItemID);
            roleModelTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            roleModelTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);

            var roleLanguageModelTypeBuilder = modelBuilder.Entity<RoleLanguagePO>();
            roleLanguageModelTypeBuilder.ToTable("t_sec_role_l").HasKey(x => x.MPKID);
            roleLanguageModelTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            roleLanguageModelTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
            roleLanguageModelTypeBuilder.HasOne(x => x.Role).WithMany(x => x.Languages).HasForeignKey(x => x.MParentID);


            var permissionTypeBuilder = modelBuilder.Entity<PermissionPO>();
            permissionTypeBuilder.ToTable("t_sec_permission").HasKey(x => x.MItemID);
            permissionTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            permissionTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);

            var permissionLanguageModelTypeBuilder = modelBuilder.Entity<RoleLanguagePO>();
            roleLanguageModelTypeBuilder.ToTable("t_sec_permission_l").HasKey(x => x.MPKID);
            roleLanguageModelTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            roleLanguageModelTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
            roleLanguageModelTypeBuilder.HasOne(x => x.Role).WithMany(x => x.Languages).HasForeignKey(x => x.MParentID);


            var userRoleRelationModelTypeBuilder = modelBuilder.Entity<UserRoleRelationPO>();
            userRoleRelationModelTypeBuilder.ToTable("t_sec_userrole").HasKey(x => x.MItemID);
            userRoleRelationModelTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            userRoleRelationModelTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);


            var rolePermissionRelationModelTypeBuilder = modelBuilder.Entity<RolePermissionRelationPO>();
            rolePermissionRelationModelTypeBuilder.ToTable("t_sec_rolepermission").HasKey(x => x.MItemID);
            rolePermissionRelationModelTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            rolePermissionRelationModelTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);

        }
    }
}
