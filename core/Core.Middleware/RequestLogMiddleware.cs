using Core.Common;
using Core.Context;
using Core.Log;
using Core.Log.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace Core.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate next;

        public RequestLogMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            SendRequestLog(context);
            await next(context);
        }

        

        private async void SendRequestLog(HttpContext httpContext)
        {
            var loggerFactory = BaseLoggerFactory.Instance();

            var request = httpContext.Request;

            LogDTO log = new LogDTO()
            {
                AppName = ConfigurationManager.AppSetting("AppName"),
                Level = LogLevelType.Error,
                Type = LogType.Exception,
                RequestId = TokenContext.CurrentContext != null ? TokenContext.CurrentContext.GetRequestId() : null,
                Content = new
                {
                    RequestURL = request.Host + request.Path,
                    RequestMethod = request.Method,
                    RequestData = GetRequestData(request),
                    RequestToken = GetRequestToken(request),
                    UserId = TokenContext.CurrentContext != null ? TokenContext.CurrentContext.GetUserId() : null,
                    OrganizationId = TokenContext.CurrentContext != null ? TokenContext.CurrentContext.GetOrganizationId() : null,
                }
            };

            loggerFactory.Write(log);
        }

        /// <summary>
        /// 获取请求参数
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetRequestData(HttpRequest request)
        {
            var method = request.Method.ToLower();
            string result = null;

            switch (method)
            {
                case "get":
                case "delete":
                    result = request.QueryString.Value;
                    break;
                case "put":
                case "post":
                    request.EnableBuffering();
                    var reader = new StreamReader(request.Body);
                    var bodyConent = reader.ReadToEnd();
                    request.Body.Position = 0;
                    result = bodyConent;
                    break;
                default:
                    result = "没有请求参数";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private string GetRequestToken(HttpRequest request)
        {
            string result = "请求没有token参数";

            var token = new StringValues();

            if (request.Headers.TryGetValue("token", out token))
            {
                result = token.ToString();
            }

            return result;
        }

        /// <summary>
        /// 获取异常字符串
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        private string GetExceptionMessage(Exception ex)
        {
            string result = $"异常消息：{ex.Message} 异常堆栈：{ex.StackTrace}";

            return result;
        }
    }
}
