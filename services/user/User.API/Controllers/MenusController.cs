using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Model.Model;

namespace User.API.Controllers
{
    [Route("api/v1/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        [HttpGet]
        public MenuModel Get(string userId , string organizationId)
        {
            MenuModel result = new MenuModel();

            return result;
        }
    }
}