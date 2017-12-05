using System.Collections.Generic;
using DigitalThesisRegistration.Helpers;
using DTRBLL.BusinessObjects;
using DTRBLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThesisRegistration.Controllers
{
    [Produces("application/json")]
    [Route("api/Appendix")]
    public class AppendixController : Controller
    {
        private readonly IAppendixService _service;

        public AppendixController(IAppendixService service)
        {
            _service = service;
        }

        /// <summary>
        /// GET Appendix
        /// </summary>
        /// <returns>Appendix</returns>
        // GET: api/Appendix
        [HttpGet]
        public IActionResult Load()
        {
            var result = _service.Load();
            if (result == null) return new NotFoundObjectResult(ErrorMessages.NotFoundString);
            return new OkObjectResult(result);
        }

        /// <summary>
        /// PUT new information on Appendix
        /// </summary>
        /// <param name="appendix">Updated appendix</param>
        /// <returns>State of update</returns>
        // PUT: api/Appendix/5
        [HttpPut]
        public IActionResult Save([FromBody] AppendixBO appendix)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }
            var saved = _service.Save(appendix);
            if (saved)
            {
                return new OkObjectResult("Appendix updated!");
            }
            else
            {
                return new BadRequestObjectResult("Couldn't save file");
            }
        }
    }
}