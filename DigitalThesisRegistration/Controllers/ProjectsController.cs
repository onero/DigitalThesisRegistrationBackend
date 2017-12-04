using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalThesisRegistration.Helpers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThesisRegistration.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET all projects
        /// </summary>
        /// <returns>Collection of ProjectBOs</returns>
        // GET: api/AssignedProjects
        [HttpGet]
        public IEnumerable<ProjectBO> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// GET a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ProjectBO, if id exists</returns>
        // GET: api/AssignedProjects/5
        [HttpGet("{id}", Name = "GetProject")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
            {
                return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            }
            return new OkObjectResult(result);
        }

        /// <summary>
        /// POST a new project
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Created ProjectBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Projects
        ///     {
        /// 
        ///     }
        ///
        /// </remarks>
        // POST: api/AssignedProjects
        [HttpPost]
        public IActionResult Post([FromBody]ProjectBO value)
        {
            if (value == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            return new OkObjectResult(_service.Create(value));
        }

        /// <summary>
        /// PUT updated information on a project by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Updated ProjectBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Projects/1
        ///     {
        ///        "id": 1,
        ///        "description": "Description,
        ///        "start": "2017-12-19T23:00:00",
        ///        "end": "2018-01-19T23:00:00",
        ///        "title": "Digital Thesis Registration",
        ///        "wantedSupervisorId": 1,
        ///        "assignedSupervisorId": 1
        ///     }
        ///
        /// Validation performed upon request:
        /// 
        ///     - entity cannot be null, returns BadRequestResult
        ///     - id must match id of provided entity, returns BadRequestResult
        ///     - The [Required] attributes of entity must be provided, returns BadRequestResult
        ///     - id of entity must exist, returns NotFoundObjectResult
        /// </remarks>
        // PUT: api/AssignedProjects/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]ProjectBO value)
        {
            if (value == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            if (id != value.Id) return new BadRequestObjectResult(ErrorMessages.MismatchingIdString);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            var result = _service.Update(value);
            if (result == null) return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
