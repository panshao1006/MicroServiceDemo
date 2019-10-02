using Core.Cache;
using Core.Cache.Redis;
using Core.EventBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseData.Common.DI
{
    public static class  DIRegisterExtensions
    {
        public static void UseDIRegister(this IServiceCollection services)
        {
            //配置一个依赖注入映射关系
            //services.AddTransient(typeof(IOrganizationBusiness), typeof(OrganizationBusiness));
            services.AddTransient(typeof(ICache), typeof(RedisClientCache));

            //services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));

            services.AddTransient<DefaultAccountCreateEventHandler>();
            //services.AddTransient<AuthorCreatedHandler>();

            services.AddSingleton<IEventHandlerExecutionContext>(sp => new RabbitMQEventHandlerExecutionContext(services));
            services.AddSingleton<IEventBus, RabbitMQEventBus>();


        }
    }
}
