using Core.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Context
{
    public class TokenContextMiddleware
    {
        private RequestDelegate _nextDelegate;

        /// <summary>
        /// 获取验证白名单
        /// </summary>
        private List<string> ValidateWhiteList
        {
            get
            {
                string configWhiteList = ConfigurationManager.AppSetting("TokenValidateWhiteList");

                List<string> result = string.IsNullOrWhiteSpace(configWhiteList) ? new List<string>() : configWhiteList.Split(';').ToList();

                result.ForEach(x =>
                {
                    x = x.ToLower();
                });

                return result;
            }
        }

        public TokenContextMiddleware(RequestDelegate nextDelegate)
        {
            _nextDelegate = nextDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var token = httpContext.Request.Headers.Keys.Contains("token") ? httpContext.Request.Headers["token"].ToString() : null;

            var requestPath = httpContext.Request.Path.ToString();

            //如果时创建会话，就不进行权限校验了，其他都要进行权限校验
            if (!IsInWhiteList(requestPath))
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    var result = new { Success = false, Message = "header token is empty", Code = "0001" };

                    httpContext.Request.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }

                var tokenModel = GetToken(token);

                if (tokenModel == null)
                {
                    var result = new { Success = false, Message = "无法找到token", Code = "0002" };

                    httpContext.Request.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }

                //初始化token上下文
                TokenContext tokenContext = TokenContext.BeginContextRuntime(tokenModel.Token, tokenModel.OrganizationId, tokenModel.UserId);

                await _nextDelegate.Invoke(httpContext);

                //完成请求以后，释放掉当前上下文
                tokenContext.Dispose();
            }
            else
            {
                await _nextDelegate.Invoke(httpContext);
            }
        }


        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private TokenDTO GetToken(string token)
        {
            TokenDTO result = null;

            HttpClientUtility httpClient = new HttpClientUtility();
            string url = "http://localhost:6000/api/v1/sessions?token=" + token;

            ResponseResult checkTokenResult = httpClient.Get<ResponseResult>(url);

            if (checkTokenResult.Success)
            {
                result = JsonConvert.DeserializeObject<TokenDTO>(checkTokenResult.Data.ToString());
            }

            return result;
        }

        /// <summary>
        /// 请求是否在白名单中
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool IsInWhiteList(string requestPath)
        {
            return ValidateWhiteList.Contains(requestPath.ToLower());
        }
    }

    internal class ResponseResult
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { set; get; }

        public object Data { set; get; }

        public string Message { set; get; }

        public string Code { set; get; }
    }

    internal class TokenDTO
    {
        /// <summary>
        /// token值
        /// </summary>
        public string Token { set; get; }

        /// <summary>
        /// 用户id
        /// </summary>
        public string UserId { set; get; }

        public string OrganizationId { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDateTime { set; get; }


        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime ExpireDateTime { set; get; }
    }
}
