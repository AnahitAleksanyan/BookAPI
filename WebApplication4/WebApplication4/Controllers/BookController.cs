using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(BookInstanceStorage.bookRepository.GetBooks());
        }

        [HttpGet("byId")]
        public ActionResult<Book?> GetById([FromQuery][Required] int id)
        {
            return BookInstanceStorage.bookRepository.GetBookById(id);
        }

        [HttpPost("create")]
        public ActionResult<Book> Create([FromBody][Required] Book book)
        {
            return Created("", BookInstanceStorage.bookRepository.CreateBook(book));
        }

        [HttpDelete("delete")]
        public ActionResult<MessageResponse> Delete([FromQuery][Required] int id)
        {
            bool success = BookInstanceStorage.bookRepository.DeleteBook(id);
            if (success)
            {
                return Ok(new MessageResponse()
                {
                    Message = "Book has been deleted successfully"
                });
            }
            else
            {
                return BadRequest(new MessageResponse()
                {
                    Message = "Couldn't delete the book"
                });
            }
        }
    }
}
