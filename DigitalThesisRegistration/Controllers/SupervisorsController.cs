using System;
using System.Collections.Generic;
using DigitalThesisRegistration.Helpers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThesisRegistration.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Supervisors")]
    public class SupervisorsController : Controller
    {
        private readonly ISupervisorService _service;

        public SupervisorsController(ISupervisorService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET all supervisors
        /// </summary>
        /// <returns>Collection of SupervisorBOs</returns>
        // GET: api/Supervisors
        [HttpGet]
        public IEnumerable<SupervisorBO> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// GET a supervisor by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>SupervisorBO, if id exists</returns>
        // GET: api/Supervisors/5
        [HttpGet("{id}", Name = "GetSupervisor")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
                return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// POST a new supervisor
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Created SupervisorBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Supervisors
        ///     {
        ///        "FirstName": "Mathias",
        ///        "LastName": "Sejrup"
        ///     }
        ///
        /// </remarks>
        // POST: api/Supervisors
        [HttpPost]
        public IActionResult Post([FromBody] SupervisorBO value)
        {
            if (value == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            return new OkObjectResult(_service.Create(value));
        }

        // PUT: api/Supervisors/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
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