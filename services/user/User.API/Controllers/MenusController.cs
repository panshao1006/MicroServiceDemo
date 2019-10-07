using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using User.Interface.BLL;
using User.Model;
using User.Model.DTO;

namespace User.API.Controllers
{
    [Route("api/v1/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private IMenuBusiness _menuBusiness;

        public MenusController(IMenuBusiness menuBusiness)
        {
            _menuBusiness = menuBusiness;
        }

        [HttpGet]
        public ResponseResult Get(string userId , string organizationId)
        {
            ResponseResult result = new ResponseResult();

            var queryResult = _menuBusiness.GetMenus(userId, organizationId);

            result.Success = queryResult.Success;
            result.Message = queryResult.Message;
            result.Data = queryResult.Data;

            return result;
        }
    }
}