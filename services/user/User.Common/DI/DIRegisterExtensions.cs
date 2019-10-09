using Core.Cache;
using Core.Cache.Redis;
using Core.EventBus;
using Core.Log;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using User.BLL;
using User.BLL.Author;
using User.BLL.EventHandler;
using User.BLL.User;
using User.DAL;
using User.Interface.BLL;
using User.Interface.DAL;

namespace User.Common.DI
{
    public static class DIRegisterExtensions
    {
        public static void UseDIRegister(this IServiceCollection services)
        {
            //配置一个依赖注入映射关系
            services.AddTransient(typeof(IUserBusiness), typeof(UserBusiness));
            services.AddTransient(typeof(ISessionBusiness), typeof(SessionBusiness));
            services.AddTransient(typeof(ICache), typeof(RedisClientCache));
            services.AddTransient(typeof(IAuthorBusiness), typeof(AuthorBusiness));
            services.AddTransient(typeof(IMenuBusiness), typeof(MenuBusiness));

            //注册DAL层的依赖注入
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddTransient(typeof(IAuthorRepository), typeof(AuthorRepository));
            services.AddTransient(typeof(IMenuRepository), typeof(MenuRepository));

            services.AddSingleton<IEventHandlerExecutionContext>(sp => new RabbitMQEventHandlerExecutionContext(services));
            services.AddSingleton<IEventBus, RabbitMQEventBus>();

            services.AddTransient<OrganizationCreatedEventHandler>();
        }
    }
}
