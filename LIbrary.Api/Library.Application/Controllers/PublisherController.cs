using Library.Business;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IBusiness<Publisher> _publisherBusiness;
        private readonly ILogger<PublisherController> _logger;

        public PublisherController(IBusiness<Publisher> publisherBusiness, ILogger<PublisherController> logger)
        {
            _logger = logger;
            _publisherBusiness = publisherBusiness;
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult<List<Publisher>> GetAll()
        {
            _logger.LogInformation("Received GET all from Publisher request");
            var result = _publisherBusiness.Query();
            return Ok(result);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public ActionResult<List<Publisher>> GetByID(int id)
        {
            _logger.LogInformation($"Received GET by id value: {id} from Publisher request");
            var result = _publisherBusiness.Query();
            return Ok(result);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<string> Post([FromBody] Publisher Publisher)
        {
            _logger.LogInformation($"Received Post from Publisher request with parameter value Publisher: {Publisher.ID} - {Publisher.Name} ");
            if (!ModelState.IsValid) return BadRequest(Publisher);
            _publisherBusiness.Insert(Publisher);
            return Ok(RedirectToAction());
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] Publisher Publisher)
        {
            _logger.LogInformation($"Received Put from Publisher request with parameter value Publisher: {Publisher.ID} - {Publisher.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Publisher");
            _publisherBusiness.Update(Publisher);
            return Ok("Update Success");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete([FromBody] Publisher Publisher)
        {
            _logger.LogInformation($"Received Delete from Publisher request with parameter value Publisher: {Publisher.ID} - {Publisher.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Publisher");
            _publisherBusiness.Delete(Publisher);
            return Ok("Delete Success");
        }
    }
}