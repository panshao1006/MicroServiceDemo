using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.DTO;
using User.Infrastructure;

namespace User.API.Controllers
{
    /// <summary>
    /// 账号相关api控制器
    /// </summary>
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private UserApplicationService _userApplicationService = null;


        public UsersController(UserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        
        //public OperationResult Get(string id)
        //{
        //    _userApplicationService
        //}

        //[HttpGet]
        //public ResponseResult Get(UserFilter filter)
        //{
        //    ResponseResult result = new ResponseResult();

        //    var userModel = _userBusiness.GetUser(filter.Email, filter.Password);

        //    if (userModel == null)
        //    {
        //        result.Success = false;
        //        result.Code = "1000"; 

        //        return result;
        //    }

           
        //    result.Data = userModel;

        //    return result;
        //}

        //[HttpGet("{token}")]
        //public ResponseResult Get(string token)
        //{
        //    ResponseResult result = new ResponseResult();

        //    var userModel = _userBusiness.GetUserByToken(token);

        //    if (userModel == null)
        //    {
        //        result.Success = false;
        //        result.Code = "1000";

        //        return result;
        //    }

        //    result.Success = true;
        //    result.Data = userModel;

        //    return result;
        //}


        /// <summary>
        /// 注册一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(UserDTO user)
        {
            var result = _userApplicationService.CreateUser(user);
           
            return result;
        }

        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public OperationResult Put(UserDTO user)
        {
            OperationResult result = _userApplicationService.UpdateUser(user);

            return result;
        }
    }
}
