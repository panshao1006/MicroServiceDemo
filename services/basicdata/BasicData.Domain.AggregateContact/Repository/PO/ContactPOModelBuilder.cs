using BasicData.Infrastructure.Data;
using Core.Context;
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

            var contactLanguageEntityTypeBuilder = modelBuilder.Entity<ContactLanguagePO>();
            contactLanguageEntityTypeBuilder.ToTable("t_bd_contacts_l");
            contactLanguageEntityTypeBuilder.HasKey(x => x.MPKID);

            contactLanguageEntityTypeBuilder.HasOne(x => x.Contact).WithMany(x => x.Languages).HasForeignKey(x => x.MParentID);
            contactLanguageEntityTypeBuilder.Property(e => e.MIsActive)
               .HasColumnType("bit(1)")
               .HasDefaultValue(false);

            contactLanguageEntityTypeBuilder.Property(e => e.MIsActive)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            var contactTypeEntityTypeBuilder = modelBuilder.Entity<ContactGroupPO>();
            contactTypeEntityTypeBuilder.ToTable("t_bd_contactstype").HasKey(x=>x.MItemID);

            contactTypeEntityTypeBuilder.HasQueryFilter(x => !x.MIsDelete);
            //contactTypeEntityTypeBuilder.HasQueryFilter(x => x.MOrgID == TokenContext.CurrentContext.GetOrganizationId());

            contactTypeEntityTypeBuilder.Property(e => e.MIsActive)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            contactTypeEntityTypeBuilder.Property(e => e.MIsDelete)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            var contactTypeLanguageEntityTypeBuilder = modelBuilder.Entity<ContactGroupLanguagePO>();
            
            contactTypeLanguageEntityTypeBuilder.ToTable("t_bd_contactstype_l");

            contactTypeLanguageEntityTypeBuilder.Property(e => e.MIsActive)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            contactTypeLanguageEntityTypeBuilder.Property(e => e.MIsDelete)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            contactTypeLanguageEntityTypeBuilder.HasOne(x => x.ContactGroup).WithMany(x => x.Languages).HasForeignKey(x => x.MParentID);
            contactTypeLanguageEntityTypeBuilder.HasKey(x => x.MPKID);

        }
    }
}
