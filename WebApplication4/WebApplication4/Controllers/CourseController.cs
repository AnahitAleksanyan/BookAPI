using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        public CourseController(ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;

        }

        [HttpGet]
        //api/course GET
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return Ok(await _courseService.GetCourses());
        }

        [HttpGet("{id}")]
        //api/course/2 GET
        public async Task<ActionResult<Student>> GetCourseById([FromRoute]int id)
        {
            try
            {
                return Ok(await _courseService.GetCourseById(id));
            }
            catch(InvalidIdException)
            {
                return BadRequest(new MessageResponse
                {
                    Message = "Invalid Ids"
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(CourseCreateDTO courseDTO)
        {
            try
            {
                return Created("", await _courseService.CreateCourse(courseDTO));
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = ex.Message,
                });
            }
        }

        [HttpPut]
        public async Task<ActionResult<Course>> Update(CourseUpdateDTO course)
        {
            try
            {
                var result = await _courseService.UpdateCourse(course);
                return result;
            }
            catch (InvalidIdException)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = "Id is invalid"
                });
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
        public async Task<ActionResult<MessageResponse>> Delete([FromQuery][Required] int id)

        {
            bool success = await _courseService.DeleteCourse(id);
            if (success)
            {
                return Ok(new MessageResponse()
                {
                    Message = "Course has been deleted successfully"
                });
            }
            else
            {
                return BadRequest(new MessageResponse()
                {
                    Message = "Couldn't delete the course"
                });
            }
        }

        //api/course/assign-student POST
        [HttpPost("assign-student")]
        public async Task<ActionResult<MessageResponse>> AssignStudent(EnrollmentCreateDTO enrollmentCreateDTO)
        {
            try
            {
                var success = await _courseService.AssignStudent(enrollmentCreateDTO);
                if (success)
                {
                    return Ok(new MessageResponse()
                    {
                        Message = "Enrollment was successfully created."
                    });
                }
                return BadRequest(new MessageResponse()
                {
                    Message = "Something went wrong."
                });
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = ex.Message
                });
            }
        }

        //api/course/students?courseId=8 POST
        [HttpPost("students")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Student>))]
        [SwaggerResponse(statusCode: 400, type: typeof(MessageResponse))]
        public async Task<ActionResult<List<Student>>> GetCourseStudents([FromQuery][Required]int id)
        {
            try
            {
                var students = await _courseService.GetCourseStudents(id);
                return Ok(students);
            }
            catch (CustomValidationException ex)
            {
                return BadRequest(new MessageResponse()
                {
                    Message = ex.Message
                });
            }
        }
    }
}

