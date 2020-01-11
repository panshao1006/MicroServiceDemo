using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using AutoMapper;
using Core.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;

namespace BasicData.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAssembly(this IServiceCollection services, string assemblyName, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services) + "为空");

            if (String.IsNullOrEmpty(assemblyName))
                throw new ArgumentNullException(nameof(assemblyName) + "为空");

            var assembly = GetAssemblyByName(assemblyName);

            if (assembly == null)
                throw new DllNotFoundException(nameof(assembly) + ".dll不存在");

            //找到当前程序集的类集合
            var types = assembly.GetTypes();
            //过滤筛选（是类文件，并且不是抽象类，不是泛型）
            var list = types.Where(o => o.IsClass && !o.IsAbstract && !o.IsGenericType).ToList();
            if (list == null && !list.Any())
                return;
            //遍历获取到的类
            foreach (var type in list)
            {
                switch (serviceLifetime)
                {
                    //根据条件，选择注册依赖的方法
                    case ServiceLifetime.Scoped:
                        //将获取到的接口和类注册进去
                        services.AddScoped(type);
                        break;
                    case ServiceLifetime.Singleton:
                        services.AddScoped(type);
                        break;
                    case ServiceLifetime.Transient:
                        services.AddTransient(type);
                        break;
                }
            }
        }


        /// <summary>
        /// automapper注册，包括profile配置文件
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMappers(this IServiceCollection services)
        {
            var assemblyNames = GetAssemblyFromConfiguration(ConfigurationManager.AppSetting("AutoMapperIocAssemblys"));

            if(assemblyNames==null || assemblyNames.Count == 0)
            {
                return;
            }

            var assemblys = new List<Assembly>();

            foreach (var assemblyName in assemblyNames)
            {
                assemblys.Add(GetAssemblyByName(assemblyName));
            }
            services.AddAutoMapper(assemblys);

        }

        /// <summary>
        /// 应用服务， 领域服务注入
        /// </summary>
        /// <param name="services"></param>
        public static void AddGloabalIoc(this IServiceCollection services)
        {
            var assemblyNames = GetAssemblyFromConfiguration(ConfigurationManager.AppSetting("IocAssemblys"));

            if(assemblyNames == null || assemblyNames.Count == 0)
            {
                return;
            }

            foreach(var assemblyName in assemblyNames)
            {
                services.AddAssembly(assemblyName, ServiceLifetime.Transient);
            }
        }

        /// <summary>
        /// 获取程序集
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Assembly GetAssemblyByName(string assemblyName)
        {
            return AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(assemblyName));
        }

        /// <summary>
        /// 从配置文件中获取程序集名称
        /// </summary>
        /// <param name="configurationKey"></param>
        /// <returns></returns>
        private static List<string> GetAssemblyFromConfiguration(string configurationKey)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(configurationKey))
            {
                return result;
            }

            result.AddRange(configurationKey.Split(',').ToList());

            return result;
        }

    }
}
