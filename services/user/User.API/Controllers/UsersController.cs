using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using User.Interface.BLL;
using User.Model;
using User.Model.Filter;
using User.Model.Model;
using User.Model.Model.User;
using User.Model.ViewModel;

namespace User.API.Controllers
{
    /// <summary>
    /// 账号相关api控制器
    /// </summary>
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private IUserBusiness _userBusiness = null;


        public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }


        [HttpGet]
        public ResultModel Get(UserFilter filter)
        {
            ResultModel result = new ResultModel();

            var userModel = _userBusiness.GetUser(filter.Email, filter.Password);

            if (userModel == null)
            {
                result.Success = false;
                result.Code = "1000"; 

                return result;
            }

           
            result.Data = userModel;

            return result;
        }

        [HttpPost]
        public ResultModel Post([FromBody]UserModel user)
        {
            var operationResult = _userBusiness.InsertUser(user);

            var result = new ResultModel();

            if (!operationResult.Success)
            {
                result.Message = operationResult.Message;
                return result;
            }

            result.Success = true;

            result.Data = new { Id = operationResult.Id };

            return result;
        }
    }
}
