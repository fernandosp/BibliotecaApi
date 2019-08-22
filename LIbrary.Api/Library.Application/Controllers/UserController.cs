using Library.Business;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBusiness<User> _userBusiness;
        private readonly ILogger<UserController> _logger;

        public UserController(IBusiness<User> userBusiness, ILogger<UserController> logger)
        {
            _logger = logger;
            _userBusiness = userBusiness;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            _logger.LogInformation("Received GET all from User request");
            var result = _userBusiness.Query();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<List<User>> GetByID(int id)
        {
            _logger.LogInformation($"Received GET by id value: {id} from User request");
            var result = _userBusiness.Query();
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] User User)
        {
            _logger.LogInformation($"Received Post from User request with parameter value User: {User.ID} - {User.Name} ");
            if (!ModelState.IsValid) return BadRequest(User);
            _userBusiness.Insert(User);
            return Ok(RedirectToAction());
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] User User)
        {
            _logger.LogInformation($"Received Put from User request with parameter value User: {User.ID} - {User.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid User");
            _userBusiness.Update(User);
            return Ok("Update Success");
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete([FromBody] User User)
        {
            _logger.LogInformation($"Received Delete from User request with parameter value User: {User.ID} - {User.Name}");
            if (!ModelState.IsValid) return BadRequest("Invalid User");
            _userBusiness.Delete(User);
            return Ok("Delete Success");
        }
    }
}