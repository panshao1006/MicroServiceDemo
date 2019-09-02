using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Model;

namespace User.API.Controllers
{
    /// <summary>
    /// 权限相关控制器
    /// </summary>
    [Route("api/authorization")]
    public class AuthorizationController : Controller
    {
        /// <summary>
        /// tooken校验方法
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("validate")]
        public ResultModel Validate([FromHeader]string token)
        {
            ResultModel result = new ResultModel();

            if (string.IsNullOrWhiteSpace(token))
            {
                result.Message = "token is null";

                return result;
            }

            return result;
        }
    }
}