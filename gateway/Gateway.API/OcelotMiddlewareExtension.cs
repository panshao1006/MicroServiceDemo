using Gateway.Common;
using Gateway.Common.Model;
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
        public static async Task AuthenticationMiddlewareAsync(DownstreamContext ctx , Func<Task> next)
        {
            var request = ctx.HttpContext.Request;

            var token = request.Headers["token"];

            var requestPath = request.Path.ToString();

            //如果时创建会话，就不进行权限校验了，其他都要进行权限校验
            if (requestPath.ToLower() != "/api/v1/sessions")
            {
                //如果没有登录
                if (string.IsNullOrWhiteSpace(token))
                {
                    ResponseResult result = new ResponseResult() { Success = false, Message = "header token is empty", Code = "0001" };

                    ctx.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }

                HttpClientUtility httpClient = new HttpClientUtility();
                string url = "http://localhost:6000/api/v1/sessions?token" + token;

                ResponseResult checkTokenResult = httpClient.Get<ResponseResult>(url);

                if (!checkTokenResult.Success)
                {
                    ResponseResult result = new ResponseResult() { Success = false, Message = "not login", Code = "0002" };

                    ctx.HttpContext.Response.Body.Write(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(result)));

                    return;
                }
            }

            await next.Invoke();

        }
    }
}
