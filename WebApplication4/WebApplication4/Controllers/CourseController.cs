using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;


namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
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

