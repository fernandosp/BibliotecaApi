using Library.Business;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly IBusiness<Reserve> _reserveBusiness;
        private readonly ILogger<ReserveController> _logger;

        public ReserveController(IBusiness<Reserve> autorBusiness, ILogger<ReserveController> logger)
        {
            _logger = logger;
            _reserveBusiness = autorBusiness;
        }

        [HttpGet]
        public ActionResult<List<Reserve>> GetAll()
        {
            _logger.LogInformation("Received GET all from Reserve request");
            var result = _reserveBusiness.Query();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Reserve>> GetByID(int id)
        {
            _logger.LogInformation($"Received GET by id value: {id} from Reserve request");
            var result = _reserveBusiness.Query();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Reserve Reserve)
        {
            _logger.LogInformation($"Received Post from Reserve request with parameter value Reserve:  Book: {Reserve.Book.Title} - User: {Reserve.User.Name}");
            if (!ModelState.IsValid) return BadRequest(Reserve);
            _reserveBusiness.Insert(Reserve);
            return Ok(RedirectToAction());
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] Reserve Reserve)
        {
            _logger.LogInformation($"Received Put from Reserve request with parameter value Reserve: Book: {Reserve.Book.Title} - User: {Reserve.User.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Reserve");
            _reserveBusiness.Update(Reserve);
            return Ok("Update Success");
        }

        [HttpDelete]
        public ActionResult<string> Delete([FromBody] Reserve Reserve)
        {
            _logger.LogInformation($"Received Delete from Reserve request with parameter value Reserve:  Book: {Reserve.Book.Title} - User: {Reserve.User.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Reserve");
            _reserveBusiness.Delete(Reserve);
            return Ok("Delete Success");
        }

    }
}