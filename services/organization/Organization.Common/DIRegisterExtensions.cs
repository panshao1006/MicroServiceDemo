using Core.Cache;
using Core.Cache.Redis;
using Core.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Organization.BLL;
using Organization.BLL.EventHandler;
using Organization.DAL;
using Organization.Interface.BLL;
using Organization.Interface.DAL;
using System.Collections.Generic;

namespace Organization.Common
{
    public static class DIRegisterExtensions
    {
        public static void UseDIRegister(this IServiceCollection services)
        {
            //配置一个依赖注入映射关系
            services.AddTransient(typeof(IOrganizationBusiness), typeof(OrganizationBusiness));
            services.AddTransient(typeof(ICache), typeof(RedisClientCache));

            services.AddTransient(typeof(IOrganizationRepository), typeof(OrganizationRepository));

            services.AddTransient<OrganizationRollbackHandler>();
            services.AddTransient<AuthorCreatedHandler>();

            services.AddSingleton<IEventHandlerExecutionContext>(sp => new RabbitMQEventHandlerExecutionContext(services));
            services.AddSingleton<IEventBus, RabbitMQEventBus>();


        }
    }
}
