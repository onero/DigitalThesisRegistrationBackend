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
    [Route("api/Groups")]
    public class GroupsController : Controller
    {
        private readonly IGroupService _service;

        public GroupsController(IGroupService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET all groups
        /// </summary>
        /// <returns>Collection of GroupBOs</returns>
        // GET: api/Groups
        [HttpGet]
        public IEnumerable<GroupBO> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// GET a group by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>StudentBO, if id exists</returns>
        // GET: api/Groups/5
        [HttpGet("{id}", Name = "GetGroup")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
                return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// POST a new group
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Created GroupBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Groups
        ///     {
        ///        "contactEmail": "D4FF"
        ///     }
        ///
        /// </remarks>
        // POST: api/Groups
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] GroupBO value)
        {
            if (value == null) return BadRequest(ErrorMessages.InvalidEntityString);
            var createdEntity = _service.Create(value);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            return new OkObjectResult(createdEntity);
        }

        /// <summary>
        /// PUT updated information on a group by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns>Updated GroupBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT api/Groups/1
        ///     {
        ///        "id": 1,
        ///        "contactEmail": "D4MegaFF"
        ///     }
        ///
        /// Validation performed upon request:
        /// 
        ///     - entity cannot be null, returns BadRequestResult
        ///     - id must match id of provided entity, returns BadRequestResult
        ///     - The [Required] attributes of entity must be provided, returns BadRequestResult
        ///     - id of entity must exist, returns NotFoundObjectResult
        /// </remarks>
        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GroupBO value)
        {
            if (value == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            if (!ModelState.IsValid) return new BadRequestObjectResult(ModelState);
            if (id != value.Id) return new BadRequestObjectResult(ErrorMessages.MismatchingIdString);
            var result = _service.Update(value);
            if (result == null) return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}