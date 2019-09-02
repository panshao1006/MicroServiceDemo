using System;
using System.Collections.Generic;
using Core.Common.Communication;
using Core.Common.ServiceFinder;
using Microsoft.AspNetCore.Mvc;
using User.Common;
using User.Interface.BLL;
using User.Model;
using User.Model.Enum;
using User.Model.Model;
using User.Model.Model.User;
using User.Model.ViewModel;

namespace User.API.Controllers
{
    /// <summary>
    /// 账号相关api控制器
    /// </summary>
    [Route("api/v1/account")]
    public class AccountController : Controller
    {
        private IUserBusiness _userBusiness = null;


        public AccountController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }


        [Route("login")]
        [HttpPost]
        public ResultModel Login(UserLoginViewModel user)
        {
            ResultModel result = new ResultModel();

            var userModel = _userBusiness.GetUser(user.Eamil, user.Password);

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

            Dictionary<string, string> postData = new Dictionary<string, string>();

            postData.Add("key", tokenModel.UserId);

            postData.Add("value", tokenModel.Token);

            ResultModel cacheResult = UriHelper.Post<ResultModel>(1, "CacheServiceName", "CacheServicePath", postData);

            result.Success = cacheResult.Success;
            result.Message = cacheResult.Message;
            result.Data = tokenModel;

            return result;
        }
    }
}
