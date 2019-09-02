using Gateway.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateway.Common.Route
{
    /// <summary>
    /// 路由帮助类，单例
    /// </summary>
    public class RouteContextHelper
    {
        private static RouteContextHelper _routeHelper;

        private List<RouteContext> _routeContextList;


        private RouteContextHelper(List<RouteContext> routeContextList)
        {
            if (routeContextList != null && routeContextList.Count > 0)
            {
                _routeContextList = routeContextList;
            }

            _routeContextList = _routeContextList ?? new List<RouteContext>();
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <returns></returns>
        public static RouteContextHelper Instance(List<RouteContext> routeContextList = null)
        {
            if (_routeHelper == null)
            {
                _routeHelper = new RouteContextHelper(routeContextList);
            }

            return _routeHelper;
        }


        /// <summary>
        /// 获取所有的上下文
        /// </summary>
        /// <returns></returns>
        public List<RouteContext> GetRouteList()
        {
            return _routeContextList;
        }


        /// <summary>
        /// 获取当个的上下文
        /// </summary>
        /// <param name="upstreamUri">上游请求地址的全称</param>
        /// <returns>如果找不到，会抛出空指针异常</returns>
        public RouteContext GetRouteContext(string upstreamUri)
        {
            if(_routeContextList == null)
            {
                throw new NullReferenceException("not read any routecontext");
            }

            RouteContext routeContext = _routeContextList.FirstOrDefault(x => x.UpstreamUri == upstreamUri);

            if(routeContext == null)
            {
                throw new NullReferenceException($"not find routecontext by {upstreamUri}");
            }

            return routeContext;
        }

        /// <summary>
        /// 获取上下文信息
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public RouteContext GetRouteContext(HttpContext httpContext)
        {
            var request = httpContext.Request;

            string host = request.Host.Value;

            string path = request.Path.Value;

            string upstreamUri =  $"{host}/{path}";

            return GetRouteContext(upstreamUri);
        }

        /// <summary>
        /// 获取路上下文信息
        /// </summary>
        /// <param name="routeContext"></param>
        /// <returns></returns>

        public RouteContext GetRouteContext(RouteContext routeContext)
        {
            string upstreamUri = routeContext.UpstreamUri;

            return GetRouteContext(upstreamUri);
        }
    }
}
