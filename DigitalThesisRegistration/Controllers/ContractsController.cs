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

        public ContractsController(IContractService service)
        {
            _service = service;
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
