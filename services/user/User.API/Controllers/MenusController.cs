using Microsoft.AspNetCore.Mvc;
using User.Model.DTO;

namespace User.API.Controllers
{
    [Route("api/v1/menus")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        [HttpGet]
        public MenuDTO Get(string userId , string organizationId)
        {
            MenuDTO result = new MenuDTO();

            return result;
        }
    }
}