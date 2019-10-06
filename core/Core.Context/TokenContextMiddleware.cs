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
        private Dictionary<string, List<string>> ValidateWhiteList
        {
            get
            {
                string configWhiteList = ConfigurationManager.AppSetting("TokenValidateWhiteList");

                List<string> whiteList = string.IsNullOrWhiteSpace(configWhiteList) ? new List<string>() : configWhiteList.Split(';').ToList();

                Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

                whiteList.ForEach(x =>
                {
                    string[] whilteListSplit = x.Split('|');

                    List<string> whilteListMethods = new List<string>();

                    if (whilteListSplit.Length >= 2)
                    {
                        whilteListMethods.AddRange(whilteListSplit[1].Split(',').ToList());
                    }

                    string key = whilteListSplit[0];
                    var value = whilteListMethods;

                    if (!string.IsNullOrWhiteSpace(key) && !result.ContainsKey(key))
                    {
                        result.Add(key, value);
                    }
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

            //如果时创建会话，就不进行权限校验了，其他都要进行权限校验
            if (!IsInWhiteList(httpContext))
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    var result = new { Success = false, Message = "header token is empty", Code = ((int)ResponseCodeType.HeaderTokenIsEmpty).ToString() };

                    httpContext.Request.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }

                var tokenModel = GetToken(token);

                if (tokenModel == null)
                {
                    var result = new { Success = false, Message = $"无法找到token{token}的相关信息", Code = ((int)ResponseCodeType.NotFindTokenInfo).ToString() };

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

            httpClient.SetRequestHeaders("token", token);

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
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool IsInWhiteList(HttpContext httpContext)
        {
            var requestPath = httpContext.Request.Path.ToString().ToLower();

            var method = httpContext.Request.Method.ToLower();

            var validateWhiteList = ValidateWhiteList;

            //逻辑是请求的url和请求的方法在白名单中
            return validateWhiteList.ContainsKey(requestPath) && (validateWhiteList[requestPath].Count == 0 || validateWhiteList[requestPath].Contains(method));
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
