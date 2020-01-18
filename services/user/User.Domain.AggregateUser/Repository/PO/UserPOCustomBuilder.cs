using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using User.Infrastructure.Data;

namespace User.Domain.AggregateUser.Repository.PO
{
    /// <summary>
    /// EFcode配置类
    /// </summary>
    public class UserPOCustomBuilder : ICustomModelBuilder
    {
        public void Builder(ModelBuilder modelBuilder)
        {
            var userTypeBuilder = modelBuilder.Entity<UserPO>();

            userTypeBuilder.ToTable("t_sec_user");
            userTypeBuilder.HasKey(x => x.MItemID);
            userTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            userTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
            userTypeBuilder.HasQueryFilter(x => !x.MIsDelete);


            var userEmailTypeBuilder = modelBuilder.Entity<UserActiveInfoPO>();
            userEmailTypeBuilder.ToTable("t_sec_sendlinkinfo");
            userEmailTypeBuilder.HasKey(x=>x.MItemID);
            userEmailTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            userEmailTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
            userEmailTypeBuilder.HasQueryFilter(x => !x.MIsDelete);
            userEmailTypeBuilder.HasOne(x => x.User).WithMany(x=>x.UserActiveInfos).HasForeignKey(x=>x.MUserID);


            //var userLanguageTypeBuilder = modelBuilder.Entity<>
        }
    }
}
