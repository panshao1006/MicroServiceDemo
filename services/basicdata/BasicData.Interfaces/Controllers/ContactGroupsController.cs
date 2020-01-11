using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicData.Application;
using BasicData.DTO.Contact;
using BasicData.Infrastructure;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicData.Interfaces.Controllers
{
    [Route("api/v1/contactgroups")]
    [ApiController]
    public class ContactGroupsController : ControllerBase
    {
        private ContactApplicationService _contactApplicationServer;

        public ContactGroupsController(ContactApplicationService contactAppliactionServer)
        {
            _contactApplicationServer = contactAppliactionServer;
        }


        [HttpGet]
        public List<ContactGroupDTO> Get()
        {
            var result = _contactApplicationServer.GetContactGroups();

            return result;
        }

        /// <summary>
        /// 创建一个分组
        /// </summary>
        /// <param name="contactGroup"></param>
        /// <returns></returns>
        [HttpPost]
        public OperationResult Post(ContactGroupDTO contactGroup)
        {
            var result = _contactApplicationServer.CreateContactGroup(contactGroup);

            return result;
        }
    }
}
