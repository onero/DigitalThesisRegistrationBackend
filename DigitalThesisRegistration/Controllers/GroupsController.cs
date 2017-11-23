using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThesisRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/Groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupService _service;

        public GroupsController(IGroupService service)
        {
            _service = service;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<GroupBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Groups/5
        [HttpGet("{id}", Name = "GetGroup")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
            {
                return new NotFoundObjectResult(result);
            }
            return new OkObjectResult(result);
        }

        // POST: api/Groups
        [HttpPost]
        public IActionResult Post([FromBody]GroupBO value)
        {
            if (value == null) return null;
            var createdEntity = _service.Create(value);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return new OkObjectResult(createdEntity);
        }
        
        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GroupBO value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
