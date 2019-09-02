using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using User.BLL.User;
using User.Interface.BLL;

namespace User.Common.DI
{
    public static class BLLDIRegister
    {
        public static void DIRegisterBLL(this IServiceCollection services)
        {
            //配置一个依赖注入映射关系
            services.AddTransient(typeof(IUserBusiness), typeof(UserBusiness));

            //注册DAL层的依赖注入
            DALDIRegister sdr = new DALDIRegister();
            sdr.DIRegisterDAL(services);
        }
    }
}
