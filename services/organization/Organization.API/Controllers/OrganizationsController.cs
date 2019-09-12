using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organization.Model;
using Organization.Model.Filter;
using Organization.Model.Model;

namespace Organization.API.Controllers
{
    [Route("api/v1/organizations")]
    public class OrganizationsController : Controller
    {
        [HttpGet]
        public ReponseResult Get(OrganizationFilter filter)
        {
            ReponseResult result = new ReponseResult();

            

            return result;
        }

        [HttpPost]
        public ReponseResult Post([FromBody]OrganizationModel user)
        {
            ReponseResult result = new ReponseResult();

            return result;
        }
    }
}
