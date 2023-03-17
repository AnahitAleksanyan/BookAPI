using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetAll()
        {
            return Ok(_bookService.GetBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<Book?> GetById([FromRoute][Required] int id)
        {
            return _bookService.GetBookById(id);
        }

        [HttpPost]
        public ActionResult<object> Create([FromBody][Required] BookCreateDTO book)
        {
            try
            {
                return Created("", _bookService.CreateBook(book));
            }
            catch (CustomValidationException ex)
            {
                Response.StatusCode = 400;
                return new MessageResponse()
                {
                    Message = ex.Message,
                };
            }
        }

        [HttpDelete]
        public ActionResult<MessageResponse> Delete([FromQuery][Required] int id)
        {
            bool success = _bookService.DeleteBook(id);
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
        [HttpDelete("all")]
        public ActionResult<MessageResponse> DeleteAllBooksByAuthorId(int authorId)
        {
            bool IsDeleted = _bookService.DeleteAllBooksByAuthorId(authorId);
            try
            {
                if (IsDeleted)
                {
                    return Ok(new MessageResponse
                    {
                        Message = "deleted all books"
                    });
                }
                else
                {
                    return BadRequest(new MessageResponse
                    {
                        Message = "Couldn't delete the books"
                    });
                }
            }
            catch (Exception)
            {
                return new MessageResponse
                {
                    Message = "Invalid Id"
                };
            }
        }

        [HttpPut]
        [SwaggerResponse(statusCode: 200, type: typeof(Book))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public ActionResult<object> Update(BookUpdateDTO book)
        {
            try
            {
                var result = _bookService.UpdateBook(book);
                return result;
            }
            catch (InvalidIdException)
            {
                Response.StatusCode = 400;
                return new MessageResponse()
                {
                    Message = "Id is invalid"
                };
            }
        }

        [HttpGet("person/{id}")]
        [SwaggerResponse(statusCode: 200, type: typeof(IEnumerable<Book>))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public ActionResult<object> GetAll([FromRoute][Required] int id)
        {
            try
            {
                return Created("", _bookService.GetBooksByAuthor(id));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = ex.Message,
                });
            }
        }
    }
}

