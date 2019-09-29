﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Organization.BLL;
using Organization.Model;
using Organization.Model.DTO;
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

            var organizations = _business.GetOrganizations(filter);

            result.Data = organizations;

            result.Success = true;

            return result;
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="org"></param>
        /// <returns></returns>
        [HttpPost]
        public ReponseResult Post([FromBody]OrganizationDTO organization)
        {
            ReponseResult result = new ReponseResult();

            OperationResult operationResult = _business.CreateOrganization(organization);

            result.Success = operationResult.Success;
            result.Message = operationResult.Message;
            if (result.Success)
            {
                result.Data = new { Id = operationResult.ObjectId };
            }
            
            return result;
        }

        /// <summary>
        /// 更新组织信息
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        [HttpPut]
        public ReponseResult Put([FromBody]DetailedOrganizationDTO organization)
        {
            ReponseResult result = new ReponseResult();

            OperationResult operationResult = _business.UpdateOrganization(organization);

            result.Success = operationResult.Success;
            result.Message = operationResult.Message;
            return result;
        }
    }
}
