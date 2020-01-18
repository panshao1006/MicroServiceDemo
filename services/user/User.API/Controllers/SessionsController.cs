using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.DTO;
using User.Infrastructure;

namespace User.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/sessions")]
    public class SessionsController : ControllerBase
    {
        private UserApplicationService _userApplicationService = null;

        

        public SessionsController(UserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        /// <summary>
        /// 获取一个会话
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public OperationResult Get(string token)
        {
            OperationResult result = new OperationResult();

            //OperationResult checkResult = _userBusiness.ValidateToken(token);

            //if (!checkResult.Success)
            //{
            //    result.Code = "100001";
            //    result.Success = false;

            //    return result;
            //}

            //result.Success = true;

            //result.Data = checkResult.Data;

            return result;
        }

        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(UserDTO user)
        {
            OperationResult result = _userApplicationService.Login(user);
            
            return result;
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        //[HttpPut]
        //public ResponseResult Put(TokenDTO tokenDTO)
        //{
        //    ResponseResult result = new ResponseResult();

        //    var organizationId = tokenDTO == null ? null : tokenDTO.OrganizationId;

        //    if (string.IsNullOrWhiteSpace(organizationId))
        //    {
        //        result.Success = false;
        //        result.Message = "组织id为空";
        //        result.Code = "100000";

        //        return result;
        //    }

        //    OperationResult operationResult = _sessionBusiness.ChangeOrganization(organizationId);

        //    result.Success = operationResult.Success;

        //    result.Data = operationResult.Data;

        //    result.Message = operationResult.Message;
            
        //    return result;
        //}


        ///// <summary>
        ///// 删除一个会话
        ///// </summary>
        ///// <param name="token"></param>
        ///// <returns></returns>
        //[HttpDelete]
        //public ResponseResult Delete(string token)
        //{
        //    ResponseResult result = new ResponseResult();

        //    return result;
        //}
    }
}