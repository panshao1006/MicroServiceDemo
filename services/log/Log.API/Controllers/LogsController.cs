using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.API.BLL;
using Log.API.Common;
using Log.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Log.API.Controllers
{
    [Route("api/v1/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post(LogDTO log)
        {
            var business = new LogBusiness();

            business.Send(log);
        }
    }
}
