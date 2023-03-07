using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet("all")]
        public IEnumerable<Book> GetAll()
        {
            return BookInstanceStorage.bookRepository.GetBooks();
        }

        [HttpGet("byId")]
        public Book? GetById([FromQuery][Required] int id)
        {
            return BookInstanceStorage.bookRepository.GetBookById(id);
        }

        [HttpPost("create")]
        public Book Create([FromBody][Required] Book book)
        {
            return BookInstanceStorage.bookRepository.CreateBook(book);
        }

        [HttpDelete("delete")]
        public MessageResponse Delete([FromQuery][Required] int id)
        {
            bool success = BookInstanceStorage.bookRepository.DeleteBook(id);
            if (success)
            {
                return new MessageResponse()
                {
                    Message = "Book has been deleted successfully"
                };
            }
            else
            {
                return new MessageResponse()
                {
                    Message = "Couldn't delete the book"
                };
            }
        }
    }
}
