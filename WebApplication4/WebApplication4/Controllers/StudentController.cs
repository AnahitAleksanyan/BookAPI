using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return Ok(await _studentService.GetStudent());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student?>> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await _studentService.GetStudentById(id));
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = "Invalid Id"
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(StudentCreateDTO studentDTO)
        {
            try
            {
                return Created("", await _studentService.CreateStudent(studentDTO));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = ex.Message
                });
            }
        }


        [HttpDelete]
        public async Task<ActionResult<MessageResponse>> DeleteStudent([FromRoute][Required]int id)
        {
              bool sucsses = await _studentService.DeleteStudent(id);
                if (sucsses)
                {
                    return Ok(new MessageResponse()
                    {
                        Message = "the Student has deleted"
                    });
                }
                else
                {
                    return BadRequest(new MessageResponse()
                    {
                        Message = "Could not  delete student"
                    });
                }
          
        }
    }



}
