using Microsoft.AspNetCore.Mvc;
using User.Interface.BLL;
using User.Model;
using User.Model.ViewModel;

namespace User.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/sessions")]
    public class SessionsController : Controller
    {
        private IUserBusiness _userBusiness = null;

        private ISessionBusiness _sesionBusiness;

        public SessionsController(IUserBusiness userBusiness , ISessionBusiness sessionBusiness)
        {
            _userBusiness = userBusiness;
            _sesionBusiness = sessionBusiness;
        }

        /// <summary>
        /// 获取一个会话
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        public ResponseResult Get(string token)
        {
            ResponseResult result = new ResponseResult();

            OperationResult checkResult = _userBusiness.ValidateToken(token);

            if (!checkResult.Success)
            {
                result.Code = "100001";
                result.Success = false;

                return result;
            }

            result.Success = true;

            result.Data = checkResult.Data;

            return result;
        }

        /// <summary>
        /// 创建一个会话
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseResult Post(UserLoginViewModel user)
        {
            ResponseResult result = new ResponseResult();

            OperationResult loginResult = _userBusiness.Login(user.Email, user.Password);

            if (!loginResult.Success || loginResult.Data == null)
            {
                result.Success = false;
                result.Code = "100000";

                return result;
            }

            result.Success = true;

            result.Data = loginResult.Data;

            return result;
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        [HttpPut]
        public ResponseResult Put([FromBody]string organizationId)
        {
            ResponseResult result = new ResponseResult();

            OperationResult operationResult = _sesionBusiness.ChangeOrganization(organizationId);

            result.Success = operationResult.Success;

            result.Data = operationResult.Data;

            result.Message = operationResult.Message;
            
            return result;
        }


        /// <summary>
        /// 删除一个会话
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpDelete]
        public ResponseResult Delete(string token)
        {
            ResponseResult result = new ResponseResult();

            return result;
        }
    }
}