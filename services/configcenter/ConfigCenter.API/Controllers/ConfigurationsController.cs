using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigCenter.API.Model;
using Core.ORM;
using Core.ORM.Sugar;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace ConfigCenter.API.Controllers
{
    [Route("api/v1/configurations")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private IORM _orm;

        public ConfigurationsController()
        {
            _orm = new SugarORM("server=127.0.0.1;database=JieNorSYS;uid=root;pwd=123456;Allow Zero Datetime=True;Port=3306;charset=utf8;pooling=true;Max Pool Size=100");
        }

        [HttpGet]
        public List<ConfigurationModel> Get(ConfigurationFilter filter)
        {
            List<ConfigurationModel> result = _orm.GetSqlClient<SqlSugarClient>().GetSimpleClient<ConfigurationModel>().GetList(x => x.EnvirmentType == filter.EnvirmentType && x.AppId == filter.AppId);

            return result;
        }
    }
}
