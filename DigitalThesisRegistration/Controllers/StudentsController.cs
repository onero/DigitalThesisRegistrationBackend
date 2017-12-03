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

        /// <summary>
        /// GET all students
        /// </summary>
        /// <returns>Collection of StudentBOs</returns>
        // GET: api/Students
        [HttpGet]
        public IEnumerable<StudentBO> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// GET a student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentBO, if id exists</returns>
        // GET: api/Students/5
        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
                return NotFound();
            return new OkObjectResult(result);
        }

        /// <summary>
        /// POST a new student
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Created StudentBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Students
        ///     {
        ///        "FirstName": "Adam",
        ///        "LastName": "Hansen"
        ///     }
        ///
        /// </remarks>
        // POST: api/Students
        [HttpPost]
        public IActionResult Post([FromBody] StudentBO value)
        {
            if (value == null) return BadRequest(value);
            //if (value.GroupId == 0) return BadRequest(value);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return new OkObjectResult(_service.Create(value));
        }

        /// <summary>
        /// PUT updated information on a student by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Updated StudentBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Students/1
        ///     {
        ///        "id": 1,
        ///        "FirstName": "Adamino",
        ///        "LastName": "Hansen"
        ///     }
        ///
        /// Validation performed upon request:
        /// 
        ///     - entity cannot be null, returns BadRequestResult
        ///     - id must match id of provided entity, returns BadRequestResult
        ///     - The [Required] attributes of entity must be provided, returns BadRequestResult
        ///     - id of entity must exist, returns NotFoundObjectResult
        /// </remarks>
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

        /// <summary>
        /// DELETE a student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}