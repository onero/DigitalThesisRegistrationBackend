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
    [Route("api/Contracts")]
    public class ContractsController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IContractService _service;

        public ContractsController(IContractService service, IProjectService projectService)
        {
            _service = service;
            _projectService = projectService;
        }

        /// <summary>
        /// GET all contracts
        /// </summary>
        /// <returns>Collection of ContractBOs</returns>
        // GET: api/Contracts
        [HttpGet]
        public IEnumerable<ContractBO> Get()
        {
            return _service.GetAll();
        }

        /// <summary>
        /// GET a contract by id
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="groupId"></param>
        /// <param name="companyId"></param>
        /// <returns>ContractBO, if id exists</returns>
        // GET: api/Contracts/5
        [HttpGet("{projectId},{groupId},{companyId}", Name = "GetContract")]
        public IActionResult Get(int projectId, int groupId, int companyId)
        {
            var result = _service.Get(projectId, groupId, companyId);
            if (result == null) return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// GET a contract by groupId
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns>ContractBO, if id exists</returns>
        [HttpGet("{groupId}", Name = "GetContractByGroupId")]
        public IActionResult Get(int groupId)
        {
            var result = _service.Get(groupId);
            if (result == null) return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// POST a new contract
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Created ContractBO, if correct format is used</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST api/Contracts
        ///     {
        ///        "projectId": 1,
        ///        "groupId": 1,
        ///        "companyId": 1
        ///     }
        ///
        /// </remarks>
        // POST: api/Contracts
        [HttpPost]
        public IActionResult Post([FromBody] ContractBO value)
        {
            if (value == null) return new BadRequestObjectResult(ErrorMessages.InvalidEntityString);
            var result = _service.Create(value);
            if (!ModelState.IsValid)
                return new BadRequestObjectResult(ModelState);
            if (value.ProjectId != 0) return new OkObjectResult(result);

            var project = _projectService.Create(new ProjectBO());
            value.ProjectId = project.Id;
            return new OkObjectResult(result);
        }

        // PUT: api/Contracts/5
        [Authorize(Roles = "Administrator, Supervisor")]
        [HttpPut("{projectId},{groupId},{companyId}")]
        public IActionResult Put(int projectId, int groupId, int companyId, [FromBody] ContractBO value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int projectId, int groupId, int companyId)
        {
            throw new NotImplementedException();
        }
    }
}