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
        private static IBook _bookList;
        public BookController(IBook bookList)
        {
            _bookList = bookList;
        }

        // POST api/<BookController>
        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookList.AddBook(book);
            return Ok("Buku berhasil ditambah.");
        }

        // GET: api/<BookController>
        [HttpGet]
        public IActionResult GetAllBook()
        {
            var menuList = _bookList.GetAllBook();
            return Ok(menuList);
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

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book editBook)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            bool existingBook = _bookList.UpdateBook(id, editBook);
            if (existingBook == false)
            {
                return NotFound();
            }
            return Ok("Data buku berhasil diupdate.");
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            bool deleteBook = _bookList.DeleteBook(id);
            if(deleteBook == false)
            {
                return NotFound();
            }
            return Ok("Data buku berhasil dihapus.");
        }
    }
}
