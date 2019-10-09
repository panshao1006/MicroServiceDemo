using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigCenter.API.Model;
using Core.ORM;
using Core.ORM.Sugar;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SqlSugar;

namespace ConfigCenter.API.Controllers
{
    [Route("api/v1/configurations")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private IORM _orm;

        public ConfigurationsController(IConfiguration configuration)
        {
            string connectionString = configuration["ConnectionString"];

            _orm = new SugarORM(connectionString);
        }

        [HttpGet]
        public ResponseResult Get([FromQuery]ConfigurationFilter filter)
        {
            ResponseResult result = new ResponseResult();

            var keyValues = new List<KeyValuePair<string, string>>();

            List<ConfigurationModel> configurations = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<ConfigurationModel>().GetList(x => x.Environment == filter.Environment && (x.AppId == filter.AppId || x.AppId == "Common") && x.IsDelete==false);

            if(configurations == null)
            {
                result.Success = false;
                
                return result;
            }

            foreach(ConfigurationModel configuration in configurations)
            {
                keyValues.Add(KeyValuePair.Create<string, string>(configuration.Key, configuration.Value));
            }

            result.Success = true;
            result.Data = keyValues;


            return result;
        }
    }
}
