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
    [Route("api/Contracts")]
    public class ContractsController : Controller
    {
        private readonly IContractService _service;
        private readonly IProjectService _projectService;

        public ContractsController(IContractService service, IProjectService projectService)
        {
            _service = service;
            _projectService = projectService;
        }

        // GET: api/Contracts
        [HttpGet]
        public IEnumerable<ContractBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Contracts/5
        [HttpGet("{id}", Name = "GetContract")]
        public IActionResult Get(int projectId, int groupId, int companyId)
        {
            var result = _service.Get(projectId, groupId, companyId);
            if (result == null) return new NotFoundObjectResult(result);
            return new OkObjectResult(result);
        }
        
        // POST: api/Contracts
        [HttpPost]
        public IActionResult Post([FromBody]ContractBO value)
        {
            if (value == null) return new BadRequestResult();
            var result = _service.Create(value);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (value.ProjectId == 0)
            {
                var project = _projectService.Create(new ProjectBO());
                value.ProjectId = project.Id;
            }
            return new OkObjectResult(result);
        }

        // PUT: api/Contracts/5
        [HttpPut("{id}")]
        public IActionResult Put(int projectId, int groupId, int companyId, [FromBody]ContractBO value)
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
