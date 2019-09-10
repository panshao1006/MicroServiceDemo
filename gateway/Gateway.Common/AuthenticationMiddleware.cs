using Core.Common.Communication;
using Gateway.Common.Model;
using Microsoft.Extensions.Configuration;
using Ocelot.Logging;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gateway.Common
{
    public class AuthenticationMiddleware: Ocelot.Middleware.OcelotMiddleware
    {
        private readonly IConfiguration _configuration;

        private readonly OcelotRequestDelegate _next;

        private string _userApiAddress = "/api/v1/sessions";

        public AuthenticationMiddleware(OcelotRequestDelegate next, IConfiguration configuration, IOcelotLoggerFactory loggerFactory) : base(loggerFactory.CreateLogger<AuthenticationMiddleware>())
        {
            _next = next;

            _configuration = configuration;
        }

        public async Task Invoke(DownstreamContext context)
        {
            string token = context.HttpContext.Request.Headers["Token"].ToString();

            string path = context.HttpContext.Request.Path;

            if(path == _userApiAddress)
            {
                await _next.Invoke(context);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    SetPipelineError(context, new UnauthenticatedError("unauthorized, need login"));
                    return;
                }

                //调用UserAPI,校验权限

                HttpClientHelper httpClient = new HttpClientHelper();

                var result = httpClient.Get<ResultModel>(_userApiAddress + "?token=" + token);

                if (!result.Success)
                {
                    SetPipelineError(context, new UnauthenticatedError("unauthorized, need login"));
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }
}
