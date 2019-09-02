using Core.Common.ConfigManager;
using Gateway.Common;
using Gateway.Common.Route;
using Gateway.Model;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Middleware.Middleware
{
    /// <summary>
    /// 路由中间件，将访问网关的地址路由到下游服务
    /// </summary>
    public class RouteMiddleware
    {
        private readonly CustomRequestDelegate _next;

        public RouteMiddleware(CustomRequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(RouteContext context)
        {
            //路由信息的初始化

            InitRouteContext(context);

            if(context == null)
            {
                //记录日志
            }
            else
            {
                await _next.Invoke(context);
            }
        }


        /// <summary>
        /// 初始化路由信息
        /// </summary>
        /// <param name="context"></param>
        private void InitRouteContext(RouteContext context)
        {
            context = RouteContextHelper.Instance().GetRouteContext(context);
        }
    }
}
