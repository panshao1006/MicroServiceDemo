using BasicData.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Domain.AggregateEmailTemplate.Repository
{
    public class EmailTemplateModelBuilder : ICustomModelBuilder
    {
        public void Builder(ModelBuilder modelBuilder)
        {
            var emailTemplateTypeBuilder = modelBuilder.Entity<EmailTemplatePO>();
            emailTemplateTypeBuilder.ToTable("t_bas_emailtemplate");
            emailTemplateTypeBuilder.HasKey(x => x.MItemID);
            emailTemplateTypeBuilder.Ignore(x => x.MOrgID);
            emailTemplateTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            emailTemplateTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);

            var emailTemplateLanguageTypeBuilder = modelBuilder.Entity<EmailTemplateLanguagePO>();
            emailTemplateLanguageTypeBuilder.ToTable("t_bas_emailtemplate_l");
            emailTemplateLanguageTypeBuilder.HasKey(x =>x.MPKID);
            emailTemplateLanguageTypeBuilder.Ignore(x => x.MOrgID);
            emailTemplateLanguageTypeBuilder.HasOne(x => x.EmailTemplate).WithMany(x => x.Languages).HasForeignKey(x => x.MParentID);
            emailTemplateLanguageTypeBuilder.Property(x => x.MIsActive).HasColumnType("bit(1)").HasDefaultValue(false);
            emailTemplateLanguageTypeBuilder.Property(x => x.MIsDelete).HasColumnType("bit(1)").HasDefaultValue(false);
        }
    }
}
