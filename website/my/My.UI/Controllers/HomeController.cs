using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My.UI.Models;

namespace My.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                HttpContext.Response.Cookies.Append("token", token);
            }
            

            return View();
        }


        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
