using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateway.Model
{
    /// <summary>
    /// 路由上下文
    /// </summary>
    public class RouteContext
    {
        /// <summary>
        /// 下游服务使用的请求方式，如http https
        /// </summary>
        public string DownstreamScheme { set; get; }

        /// <summary>
        /// 下流请求的路径
        /// </summary>
        public string DownstreamPathTemplate { set; get; }

        /// <summary>
        /// 下游请求注册的服务名称
        /// </summary>
        public string DownstreamServiceName { set; get; }


        public List<DownstreamHostInfo> DownstreamHostInfos { set; get; }


        /// <summary>
        /// 上游请求的主机信息
        /// </summary>
        public string UpstreamHost { set; get; }

        /// <summary>
        /// 上游请求的路径
        /// </summary>
        public string UpstreamPathTemplate { set; get; }

        /// <summary>
        /// 请求是否需要校验权限
        /// </summary>
        public string Authentication { set; get; }

        /// <summary>
        /// 当前请求信息
        /// </summary>
        public HttpContext HttpContext { set; get; }

        /// <summary>
        /// 获取url
        /// </summary>
        public string UpstreamUri
        {
            get
            {
                var request = HttpContext.Request;

                string host = request.Host.Value;

                string path = request.Path.Value;

                return $"{host}/{path}";
            }
        }

        public RouteContext(HttpContext context)
        {
            this.HttpContext = context;
        }
    }


    /// <summary>
    /// 下游服务的请求地址
    /// </summary>
    public class DownstreamHostInfo
    {
        public string IP { set; get; }

        public string Port { set; get; }
    }
}
