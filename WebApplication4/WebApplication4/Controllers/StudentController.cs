using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
        [SwaggerResponse(statusCode: 200, type: typeof(Student))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<MessageResponse>> DeleteStudent(int id)
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
        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(StudentUpdateDTO studentDTO)
        {
            try
            {
                return Ok(await _studentService.UpdateStudent(studentDTO));
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse
                {
                    Message = "Invalid Id"
                });
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });
            }
        }

        //api/Student/courses? studentId = 1 

        [HttpPost("courses")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Course>))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<List<Course>>> GetStudentCourses([FromQuery][Required] int studentId)
        {
            try
            {
                var courses = await _studentService.GetStudentCourses(studentId);
                return Ok(courses);
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });
            }
        }

        // api / Student/Assign-Course
        [HttpPost("assign-course")]

        public async Task<ActionResult<MessageResponse>> AssignCourse(EnrollmentCreateDTO enrollmentCreateDTO)
        {
            try
            {
                bool sucsses = await _studentService.AssignCourse(enrollmentCreateDTO);
                if (sucsses)
                {
                    return Ok(new MessageResponse
                    {
                        Message = "Created"
                    });
                }
                return BadRequest(new MessageResponse
                {
                    Message = "Does not created"
                });
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse
                {
                    Message = ex.Message
                });

            }
        }
    }

}
