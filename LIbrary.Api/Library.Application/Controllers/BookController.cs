using Library.Business;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBusiness<Book> _bookBusiness;
        private readonly ILogger<BookController> _logger;

        public BookController(IBusiness<Book> bookBusiness, ILogger<BookController> logger)
        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        // GET: api/Book
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            _logger.LogInformation("Received GET all from Book request");
            var result = _bookBusiness.Query();
            return Ok(result);
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public ActionResult<List<Book>> GetByID(int id)
        {
            _logger.LogInformation($"Received GET by id value: {id} from Book request");
            var result = _bookBusiness.Query();
            return Ok(result);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<string> Post([FromBody] Book book)
        {
            _logger.LogInformation($"Received Post from Book request with parameter value Book: {book.Title} ");
            if (!ModelState.IsValid) return BadRequest(book);
            _bookBusiness.Insert(book);
            return Ok(RedirectToAction());
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] Book book)
        {
            _logger.LogInformation($"Received Put from Book request with parameter value Book: {book.ID}");
            if (!ModelState.IsValid) return BadRequest("Invalid Book");
            _bookBusiness.Update(book);
            return Ok("Update Success");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete([FromBody] Book book)
        {
            _logger.LogInformation($"Received Delete from Book request with parameter value Book: {book.ID} - {book.Title}");
            if (!ModelState.IsValid) return BadRequest("Invalid Book");
            _bookBusiness.Delete(book);
            return Ok("Delete Success");
        }
    }
}