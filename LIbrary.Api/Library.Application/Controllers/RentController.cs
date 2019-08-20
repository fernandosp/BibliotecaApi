using Library.Business;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {

        private readonly IBusiness<Rent> _rentBusiness;
        private readonly ILogger<RentController> _logger;

        public RentController(IBusiness<Rent> rentBusiness, ILogger<RentController> logger)
        {
            _logger = logger;
            _rentBusiness = rentBusiness;
        }

        // GET: api/Rent
        [HttpGet]
        public ActionResult<List<Rent>> GetAll()
        {
            _logger.LogInformation("Received GET all from Rent request");
            var result = _rentBusiness.Query();
            return Ok(result);
        }

        // GET: api/Rent/5
        [HttpGet("{id}")]
        public ActionResult<List<Rent>> GetByID(int id)
        {
            _logger.LogInformation($"Received GET by id value: {id} from Rent request");
            var result = _rentBusiness.Query();
            return Ok(result);
        }

        // POST: api/Rent
        [HttpPost]
        public ActionResult<string> Post([FromBody] Rent Rent)
        {
            _logger.LogInformation($"Received Post from Rent request with parameter value Rent: Book {Rent.Book.Title} - User: {Rent.User.Name} ");
            if (!ModelState.IsValid) return BadRequest(Rent);
            _rentBusiness.Insert(Rent);
            return Ok(RedirectToAction());
        }

        // PUT: api/Rent/5
        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] Rent Rent)
        {
            _logger.LogInformation($"Received Put from Rent request with parameter value  Rent: Book {Rent.Book.Title} - User: {Rent.User.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Rent");
            _rentBusiness.Update(Rent);
            return Ok("Update Success");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete([FromBody] Rent Rent)
        {
            _logger.LogInformation($"Received Delete from Rent request with parameter value Rent: Book {Rent.Book.Title} - User: {Rent.User.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid Rent");
            _rentBusiness.Delete(Rent);
            return Ok("Delete Success");
        }
    }
}