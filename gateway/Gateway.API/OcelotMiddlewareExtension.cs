using Core.Common;
using Gateway.Common;
using Gateway.Common.Model;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.API
{
    public class OcelotMiddlewareExtension
    {
        public static async Task AuthenticationMiddlewareAsync(DownstreamContext ctx , Func<Task> next , IConfiguration configuration)
        {
            var request = ctx.HttpContext.Request;

            var token = request.Headers.Keys.Contains("token") ? request.Headers["token"].ToString() : null;

            var requestPath = request.Path.ToString();

            //如果时创建会话，就不进行权限校验了，其他都要进行权限校验
            if (!IsInWhiteList(requestPath , configuration))
            {
                //如果没有登录
                if (string.IsNullOrWhiteSpace(token))
                {
                    ResponseResult result = new ResponseResult()
                    {
                        Success = false,
                        Message = "header token is empty",
                        Code = ResponseCodeType.TokenIsEmpty.ToEnumString()
                    };

                    ctx.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }

                string tokenValidateUrl = configuration["WhiteList:TokenValidateURL"];

                if (string.IsNullOrWhiteSpace(tokenValidateUrl))
                {
                    ResponseResult result = new ResponseResult()
                    {
                        Success = false,
                        Message = "没有配置token校验URL",
                        Code = ResponseCodeType.NotConfigValidateTokenURL.ToEnumString()
                    };

                    ctx.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }


                HttpClientContainner httpClient = new HttpClientContainner();
                string url = tokenValidateUrl+$"?token={token}";

                ResponseResult checkTokenResult = httpClient.Get<ResponseResult>(url);

                if (!checkTokenResult.Success)
                {
                    ResponseResult result = new ResponseResult()
                    {
                        Success = false,
                        Message = "not login",
                        Code = ResponseCodeType.NotLogin.ToEnumString()
                    };

                    ctx.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }
            }

            await next.Invoke();

        }

        /// <summary>
        /// 获取校验白名单
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static List<string> ValidateWhiteList(IConfiguration configuration)
        {
            string configWhiteList = configuration["WhiteList:TokenValidateWhiteList"];

            List<string> result = string.IsNullOrWhiteSpace(configWhiteList) ? new List<string>() : configWhiteList.Split(';').ToList();

            result.ForEach(x =>
            {
                x = x.ToLower();
            });

            return result;
        }

        /// <summary>
        /// 请求是否在白名单中
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool IsInWhiteList(string requestPath , IConfiguration configuration)
        {
            return ValidateWhiteList(configuration).Contains(requestPath.ToLower());
        }
    }
}
