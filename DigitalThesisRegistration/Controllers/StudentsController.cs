using System;
using System.Collections.Generic;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThesisRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        // GET: api/Students
        [HttpGet]
        public IEnumerable<StudentBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Students/5
        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
                return NotFound();
            return new OkObjectResult(result);
        }

        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] StudentBO value)
        {
            if (value == null) return BadRequest(value);
            //if (value.GroupId == 0) return BadRequest(value);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return new OkObjectResult(_service.Create(value));
        }

        // PUT: api/Students/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StudentBO value)
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
            throw new NotImplementedException();
        }
    }
}