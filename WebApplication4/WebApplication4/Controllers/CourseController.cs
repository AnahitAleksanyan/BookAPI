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

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            return Ok(await _courseService.GetCourse());
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
    }
}

