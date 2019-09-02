using Gateway.Common;
using Gateway.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Middleware.Middleware
{
    /// <summary>
    /// 授权的中间件
    /// </summary>
    public class AuthorizationMiddleware
    {
        private readonly CustomRequestDelegate _next;

        public AuthorizationMiddleware(CustomRequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(RouteContext routeContext)
        {
            //进行权限校验

            await _next.Invoke(routeContext);
        }

    }
}
