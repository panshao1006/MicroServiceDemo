using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Login.UI.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="appId"></param>
        /// <returns></returns>
        public IActionResult Configurations(string environment , string appId)
        {
            var data = new List<KeyValuePair<string, string>>();

            return Json(data);
        }
    }
}
