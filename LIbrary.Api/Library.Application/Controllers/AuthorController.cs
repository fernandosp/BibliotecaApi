using Library.Business;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IBusiness<Author> _autorBusiness;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IBusiness<Author> autorBusiness, ILogger<AuthorController> logger)
        {
            _logger = logger;
            _autorBusiness = autorBusiness;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            _logger.LogInformation("Received GET all from Author request");
            var result = _autorBusiness.Query();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<List<Author>> GetByID(int id)
        {
            _logger.LogInformation($"Received GET by id value: {id} from Author request");
            var result = _autorBusiness.Query($"ID = {id}");
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Author author)
        {
            _logger.LogInformation($"Received Post from Author request with parameter value Author: {author.ID} - {author.Name} ");
            if (!ModelState.IsValid) return BadRequest(author);
            _autorBusiness.Insert(author);
            return Ok(RedirectToAction());
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] Author author)
        {
            _logger.LogInformation($"Received Put from Author request with parameter value Author: {author.ID} - {author.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Author");
            _autorBusiness.Update(author);
            return Ok("Update Success");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete([FromBody] Author author)
        {
            _logger.LogInformation($"Received Delete from Author request with parameter value Author: {author.ID} - {author.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Author");
            _autorBusiness.Delete(author);
            return Ok("Delete Success");
        }
    }
}