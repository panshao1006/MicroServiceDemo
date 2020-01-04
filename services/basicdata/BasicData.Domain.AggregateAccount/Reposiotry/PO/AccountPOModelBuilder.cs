using BasicData.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateAccount.Reposiotry.PO
{
    public class AccountPOModelBuilder : ICustomModelBuilder
    {
        public void Builder(ModelBuilder modelBuilder)
        {
            var accountBuilder = modelBuilder.Entity<AccountPO>();

            accountBuilder.ToTable("t_bd_account");
            accountBuilder.HasKey("MItemID");

            //bit转bool
            accountBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
            accountBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
        }
    }
}
