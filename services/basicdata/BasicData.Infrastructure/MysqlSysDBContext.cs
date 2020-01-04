using BasicData.Infrastructure.Model;
using Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicData.Infrastructure
{
    public class MysqlSysDBContext : DbContext
    {
        public DbSet<DatabaseStorage> DatabaseStorages { set; get; }

        public DbSet<OrganiztionStorageRelation> OrganiztionStorageRelations { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = ConfigurationManager.AppSetting("ConnectionString");
            optionsBuilder.UseMySQL(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DatabaseStorage>().ToTable("t_sys_storage").Property(e => e.MIsDelete)
                .HasColumnType("bit(1)")
                .HasDefaultValue(false);

            modelBuilder.Entity<OrganiztionStorageRelation>().ToTable("t_sys_orgstorage").HasOne(p => p.DatabaseStorage).WithMany(x => x.StorageRelations).HasForeignKey(x => x.MStorageID);
        }
    }
}
