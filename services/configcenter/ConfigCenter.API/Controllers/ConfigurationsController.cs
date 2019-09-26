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
        public List<KeyValuePair<string, string>> Get([FromQuery]ConfigurationFilter filter)
        {
            var result = new List<KeyValuePair<string, string>>();

            List<ConfigurationModel> configurations = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<ConfigurationModel>().GetList(x => x.Environment == filter.Environment && x.AppId == filter.AppId && x.IsDelete==false);

            if(configurations == null)
            {
                return result;
            }

            foreach(ConfigurationModel configuration in configurations)
            {
                result.Add(KeyValuePair.Create<string, string>(configuration.Key, configuration.Value));
            }
            
            return result;
        }
    }
}
