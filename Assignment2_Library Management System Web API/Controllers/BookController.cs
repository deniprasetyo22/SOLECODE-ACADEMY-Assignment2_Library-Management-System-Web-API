using Assignment2_Library_Management_System_Web_API.Interfaces;
using Assignment2_Library_Management_System_Web_API.Models;
using Assignment2_Library_Management_System_Web_API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Assignment2_Library_Management_System_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookList;
        public BookController(IBook bookList)
        {
            _bookList = bookList;
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetAllBook()
        {
            return Ok(_bookList.GetAllBook);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }
            Book book = _bookList.GetBookById(id);
            if(book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
