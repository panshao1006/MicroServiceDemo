using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicData.Application;
using BasicData.DTO.EmailTemplate;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicData.Interfaces.Controllers
{
    [ApiController]
    [Route("/api/v1/emailtemplates")]
    public class EmailTemplatesController : ControllerBase
    {
        private CommonDataAplicationService _applicationService;
        public EmailTemplatesController(CommonDataAplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// 获取邮件模板
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        public EmailTemplateDTO Get(int type)
        {
            var template = _applicationService.GetEmailTemplate(type);

            return template;
        }
    }
}
