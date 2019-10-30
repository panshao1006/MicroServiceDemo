using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseData.Interface.BLL;
using BaseData.Model;
using BaseData.Model.Filter.Account;
using Core.Context;
using Microsoft.AspNetCore.Mvc;

namespace BaseData.API.Controllers
{
    [Route("api/v1/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IAccountBusiness _accountBusiness;

        public AccountsController(IAccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpGet]
        public ResponseResult Get([FromQuery]AccountFilter filter)
        {
            ResponseResult result = new ResponseResult();

            var accountList = _accountBusiness.GetAccounts(filter);

            result.Success = true;
            result.Data = accountList;

            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
