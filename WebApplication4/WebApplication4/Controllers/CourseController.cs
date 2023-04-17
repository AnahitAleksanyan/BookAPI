using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
using System.ComponentModel.DataAnnotations;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
<<<<<<< HEAD
using WebApplication4.Services.Implementations;
using WebApplication4.Services.Interfaces;
=======

>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
<<<<<<< HEAD
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
=======
        private readonly SQLDBContext _dbContext;
        public CourseController(SQLDBContext sqlDBContext)
        {
            _dbContext = sqlDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course?>>> GetAll()
        {
            return Ok(await _dbContext.Courses.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course?>> GetById([FromRoute][Required] int id)
        {
            return Ok(await _dbContext.Courses.Where(c => c.Id == id).FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Course course)
        {
            var created = _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
