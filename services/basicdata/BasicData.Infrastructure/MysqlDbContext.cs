using BasicData.Infrastructure.Data;
using Core.Common;
using Core.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace BasicData.Infrastructure
{
    public class MysqlDbContext: DbContext
    {
        protected static readonly LoggerFactory LoggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider((_, __) => true) });

        //private string _organizationId;

        public MysqlDbContext()
        {

        }

        public MysqlDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //注册PO
            RegisterEntity(modelBuilder);
            //注册映射关系
            RegisterEntityRelationship(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = GetConnectionString();
            //SslModel=None 这和ssl协议有关系。如果不指定会报错
            optionsBuilder.UseLoggerFactory(LoggerFactory);
            optionsBuilder.UseMySQL(connectionString);
        }

        /// <summary>
        /// 获取请求的字符串
        /// </summary>
        /// <returns></returns>
        private string GetConnectionString()
        {
            string connectionString = "";

            var tokenContext = TokenContext.CurrentContext;

            if (tokenContext == null)
            {
                return "server=localhost;user=root;database=jienorsys;port=3306;password=123456;SslMode=None";
            }

            //获取请求的组织Id
            string organizationId = TokenContext.CurrentContext.GetOrganizationId();

            connectionString = DataBaseRouter.GetConnectionString(organizationId);

            return connectionString;
        }

        /// <summary>
        /// 向EFCore 上下文中注入实体
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void RegisterEntity(ModelBuilder modelBuilder)
        {
            var assemblyNames = GetAssemblyFromConfiguration(ConfigurationManager.AppSetting("ORMIocAssemblys"));

            if (assemblyNames == null || assemblyNames.Count == 0)
            {
                return;
            }

            List<Type> entitys = new List<Type>();

            foreach (var assemblyName in assemblyNames)
            {
                var assembly = GetAssemblyByName(assemblyName);

                var tempEntitys = assembly.DefinedTypes.Select(t => t.AsType()).ToList();

                if (tempEntitys == null || tempEntitys.Count == 0)
                {
                    return;
                }

                tempEntitys = tempEntitys.Where(x => (x.GetTypeInfo().IsSubclassOf(typeof(BasePO)) || x.GetTypeInfo().IsSubclassOf(typeof(BaseLanguagePO))) && !x.GetTypeInfo().IsAbstract).ToList();

                entitys.AddRange(tempEntitys);

            }

            if (entitys==null || entitys.Count == 0)
            {
                return;
            }

            foreach(var entity in entitys)
            {
                modelBuilder.Entity(entity);
            }
        }

        /// <summary>
        /// 向EFCore 上下文中注入实体关系
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void RegisterEntityRelationship(ModelBuilder modelBuilder)
        {
            var assemblyNames = GetAssemblyFromConfiguration(ConfigurationManager.AppSetting("ORMIocAssemblys"));

            if (assemblyNames == null || assemblyNames.Count == 0)
            {
                return;
            }

            List<Type> entitys = new List<Type>();

            foreach (var assemblyName in assemblyNames)
            {
                var assembly = GetAssemblyByName(assemblyName);

                var tempEntitys = assembly.DefinedTypes.Select(t => t.AsType()).ToList();

                if (tempEntitys == null || tempEntitys.Count == 0)
                {
                    return;
                }

                tempEntitys = tempEntitys.Where(x => typeof(ICustomModelBuilder).IsAssignableFrom(x)).ToList();

                entitys.AddRange(tempEntitys);

            }

            if (entitys == null || entitys.Count == 0)
            {
                return;
            }

            foreach (var entity in entitys)
            {
                if (entity != null && entity != typeof(ICustomModelBuilder))
                {
                    var builder = (ICustomModelBuilder)Activator.CreateInstance(entity);
                    builder.Builder(modelBuilder);
                }
            }
        }


        private List<string> GetAssemblyFromConfiguration(string configurationKey)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(configurationKey))
            {
                return result;
            }

            result.AddRange(configurationKey.Split(',').ToList());

            return result;
        }

        private Assembly GetAssemblyByName(string assemblyName)
        {
            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
        }

    }
}
