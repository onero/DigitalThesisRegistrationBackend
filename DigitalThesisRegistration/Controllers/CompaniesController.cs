using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using DTRBLL.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThesisRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/Companies")]
    public class CompaniesController : Controller
    {
        private ICompanyService _service;

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        // GET: api/Companies
        [HttpGet]
        public IEnumerable<CompanyBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Companies/5
        [HttpGet("{id}", Name = "GetCompany")]
        public IActionResult Get(int id)
        {
            var result = _service.Get(id);
            if (result == null)
            {
                return NotFound();
            }
            return new OkObjectResult(result);
        }
        
        // POST: api/Companies
        [HttpPost]
        public IActionResult Post([FromBody]CompanyBO value)
        {
            if (value == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return new OkObjectResult(_service.Create(value));
        }
        
        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
