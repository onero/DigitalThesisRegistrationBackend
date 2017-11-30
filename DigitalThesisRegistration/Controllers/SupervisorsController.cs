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
    [Route("api/Suporvisors")]
    public class SupervisorsController : Controller
    {
        private ISupervisorService _service;

        public SupervisorsController(ISupervisorService service)
        {
            _service = service;
        }

        // GET: api/Suporvisors
        [HttpGet]
        public IEnumerable<SupervisorBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Suporvisors/5
        [HttpGet("{id}", Name = "GetSupervisor")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }

        // POST: api/Suporvisors
        [HttpPost]
        public IActionResult Post([FromBody]SupervisorBO value)
        {
            if (value == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return new OkObjectResult(_service.Create(value));
        }

        // PUT: api/Suporvisors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
