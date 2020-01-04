using BasicData.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateContact.Repository.PO
{
    public class ContactPOModelBuilder: ICustomModelBuilder
    {
        public void Builder(ModelBuilder modelBuilder)
        {
            var contactEntityTypeBuilder = modelBuilder.Entity<ContactPO>();
            contactEntityTypeBuilder.ToTable("t_bd_contacts");
            contactEntityTypeBuilder.HasKey(x => x.MItemID);

            contactEntityTypeBuilder.Property(e => e.MIsDelete)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            contactEntityTypeBuilder.Property(e => e.MIsActive)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);
        }
    }
}
