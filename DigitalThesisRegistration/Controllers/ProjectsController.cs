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
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        // GET: api/AssignedProjects
        [HttpGet]
        public IEnumerable<ProjectBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/AssignedProjects/5
        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }
        
        // POST: api/AssignedProjects
        [HttpPost]
        public IActionResult Post([FromBody]ProjectBO value)
        {
            if (value == null) return BadRequest();
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            return new OkObjectResult(_service.Create(value));
        }
        
        // PUT: api/AssignedProjects/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProjectBO value)
        {
            if (value == null) return new BadRequestResult();
            if (id != value.Id) return new BadRequestResult();
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            var result = _service.Update(value);
            if (result == null) return new NotFoundObjectResult(result);
            return new OkObjectResult(result);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
