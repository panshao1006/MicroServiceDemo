using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using User.DAL;
using User.Interface.DAL;

namespace User.Common.DI
{
    public class DALDIRegister
    {
        public void DIRegisterDAL(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
        }
    }
}
