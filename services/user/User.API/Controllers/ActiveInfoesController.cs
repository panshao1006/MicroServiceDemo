using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace User.API.Controllers
{
    [Route("api/v1/activeinfoes")]
    [ApiController]
    public class ActiveInfoesController : ControllerBase
    {
        private UserApplicationService _userApplicationService;

        public ActiveInfoesController(UserApplicationService userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActiveInfoDTO Get(string id)
        {
            return _userApplicationService.GetActiveInfo(id);
        }

        
    }
}
