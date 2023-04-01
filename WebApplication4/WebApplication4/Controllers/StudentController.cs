using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SQLDBContext _dbContext;
        public StudentController(SQLDBContext sqlDBContext)
        {
            _dbContext = sqlDBContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student?>>> GetAll()
        {
            return Ok(await _dbContext.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student?>> GetById([FromRoute][Required] int id)
        {
            return Ok(await _dbContext.Students.Where(c => c.Id == id).FirstOrDefaultAsync());
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Student student)
        {
            _dbContext.Students.Add(student);

            await _dbContext.SaveChangesAsync(); 
            return Ok();
        }

        [HttpPost("assign-course")]
        public async Task<ActionResult> AssignCourse([FromBody][Required] CourseStudentIdsDTO courseStudentIds)
        {
            _dbContext.CourceStudentPairs.Add(new CourceStudentPairs()
            {
                CoursesId = courseStudentIds.CourseId,
                StudentsId = courseStudentIds.StudentId
            });

            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
