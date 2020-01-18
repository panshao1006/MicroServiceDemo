using Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace User.Infrastructure.Data
{
    public class MysqlDbContext : DbContext
    {
        public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //加载PO
            RegisterEntity(modelBuilder);

            //加载关系
            RegisterEntityRelationship(modelBuilder);
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

            if (entitys == null || entitys.Count == 0)
            {
                return;
            }

            foreach (var entity in entitys)
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
