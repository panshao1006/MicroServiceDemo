using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BasicData.Application;
using BasicData.DTO.Contact;
using BasicData.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BasicData.Interfaces.Controllers
{
    [Route("api/v1/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public ContactApplicationService _contactApplication;
        public ContactsController(ContactApplicationService contactApplication)
        {
            _contactApplication = contactApplication;
        }


        [HttpGet]
        public ActionResult<List<ContactDTO>> Get([FromQuery]ContactFilterDTO filter = null)
        {
            var result = _contactApplication.GetContacts(filter);

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ContactDTO> Get(string id)
        {
            var result = _contactApplication.GetContact(id);

            return result;
        }


        [HttpPost]
        public OperationResult Post([FromBody]ContactDTO contact)
        {
            var result = _contactApplication.CreateContact(contact);

            return result;
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
