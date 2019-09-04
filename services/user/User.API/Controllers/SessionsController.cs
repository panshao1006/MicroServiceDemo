using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using User.Common;
using User.Interface.BLL;
using User.Model;
using User.Model.Model;
using User.Model.ViewModel;

namespace User.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/sessions")]
    public class SessionsController : Controller
    {
        private IUserBusiness _userBusiness = null;

        public SessionsController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }


        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ResultModel Post([FromBody]UserLoginViewModel user)
        {
            ResultModel result = new ResultModel();

            var userModel = _userBusiness.GetUser(user.Email, user.Password);

            if (userModel == null)
            {
                result.Success = false;
                result.Code = "1000";

                return result;
            }

            TokenModel tokenModel = new TokenModel()
            {
                UserId = userModel.MItemID,
                UserName = userModel.MName,
                Token = Guid.NewGuid().ToString()
            };

            //调用缓存，把token保存起来

            //Dictionary<string, string> postData = new Dictionary<string, string>();

            //postData.Add("key", tokenModel.UserId);

            //postData.Add("value", tokenModel.Token);

            //ResultModel cacheResult = UriHelper.Post<ResultModel>(1, "CacheServiceName", "CacheServicePath", postData);

            //result.Success = cacheResult.Success;
            //result.Message = cacheResult.Message;
            result.Data = tokenModel;

            return result;
        }

        /// <summary>
        /// 删除一个会话
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete]
        public ResultModel Delete(string token)
        {
            ResultModel result = new ResultModel();

            return result;
        }
    }
}