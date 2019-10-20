using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Log.API.Interface;
using Log.API.Model;
using Microsoft.AspNetCore.Mvc;

namespace Log.API.Controllers
{
    [Route("api/v1/logs")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private ILoggerBusiness _loggerBusiness;

        public LogsController(ILoggerBusiness logBusiness)
        {
            _loggerBusiness = logBusiness;
        }


        [HttpPost]
        public void Post(LogDTO log)
        {
            _loggerBusiness.AddLog(log);
        }
    }
}
