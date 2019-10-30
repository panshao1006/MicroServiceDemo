using Core.Context;
using Core.ORM.DBRouter;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Model.DAO
{
    public class BaseDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(GetConnectionString());//配置连接字符串
        }

        /// <summary>
        /// 获取连接字符串
        /// </summary>
        /// <returns></returns>
        protected string GetConnectionString()
        {
            string organiztionId = TokenContext.CurrentContext.GetOrganizationId();

            if (string.IsNullOrWhiteSpace(organiztionId))
            {
                throw new Exception("无法读取当前请求的组织id");
            }

            return DatabaseRouter.GetConnectionString(organiztionId);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    var etPerson = modelBuilder.Entity<Person>().ToTable("t_persons");
        //    etPerson.Property(e => e.Age).IsRequired();//不写IsRequired,默认为可空
        //    etPerson.Property(e => e.Gender).IsRequired();
        //    etPerson.Property(e => e.Name).HasMaxLength(20).IsRequired();
        //}
    }
}
