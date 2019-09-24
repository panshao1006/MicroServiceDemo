using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organization.BLL;
using Organization.Model;
using Organization.Model.Filter;
using Organization.Model.Model;

namespace Organization.API.Controllers
{
    [Route("api/v1/organizations")]
    public class OrganizationsController : Controller
    {
        private OrganizationBusiness _business;

        public OrganizationsController()
        {
            _business = new OrganizationBusiness();
        }


        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public ReponseResult Get(OrganizationFilter filter)
        {
            ReponseResult result = new ReponseResult();

            var organizations = _business.GetList(filter);

            result.Data = organizations;

            result.Success = true;

            return result;
        }

        [HttpPost]
        public ReponseResult Post([FromBody]OrganizationModel org)
        {
            ReponseResult result = new ReponseResult();

            OperationResult operationResult = _business.CreateOrganization(org);

            result.Success = operationResult.Success;
            result.Data = new { Id = operationResult.ObjectId };
            return result;
        }
    }
}
