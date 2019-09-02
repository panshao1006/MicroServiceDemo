using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cache.BLL;
using Cache.Model;
using Cache.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Cache.API.Controllers
{
    [Route("api/cache")]
    public class CacheController : Controller
    {
        /// <summary>
        /// 获取cache
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Route("getcache")]
        public APIResultModel GetCache([FromQuery]string key)
        {
            APIResultModel result = new APIResultModel();
            return result;
        }

        /// <summary>
        /// 增加cache
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("setcache")]
        [HttpPost]
        public APIResultModel SetCache([FromBody] CacheViewModel cache)
        {
            ICacheBusiness cacheBusiness = CacheFactory.Instance("redis");

            var cacheResult = cacheBusiness.SetValue(cache.Key, cache.Value.ToString());

            APIResultModel result = new APIResultModel()
            {
                Success = cacheResult.Success,
                Message = cacheResult.Message
            };

            return result;

        }
    }
}
