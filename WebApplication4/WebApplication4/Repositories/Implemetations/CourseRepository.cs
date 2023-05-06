using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories.Implemetations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SQLDBContext _dbContext;

        public CourseRepository(SQLDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Course> CreateCourse(CourseCreateDTO courseDTO)
        {
            var course = courseDTO.ToCourse();
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }


        public async Task<bool> DeleteCourse(int id)
        {
            Course? course = await GetCourseById(id);
            if (course != null)
            {
                _dbContext.Courses.Remove(course);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<bool> Exist(int id)
        {
           
          return  await _dbContext.Courses.AnyAsync(c => c.Id == id);
            
        }

        
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _dbContext.Courses.Where(_ => true).ToListAsync();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            return await _dbContext.Courses.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Course> UpdateCourse(CourseUpdateDTO courseDTO)
        {
            Course? course = await GetCourseById(courseDTO.Id);
            if (course != null)
            {
                course.Name = courseDTO.Name;
                await _dbContext.SaveChangesAsync();
                return course;
            }
            else
            {
                return courseDTO.ToCourse();
            }
        }

        public async  Task<List<Course>> GetCoursesByStudentId(int studentId)
        {
            List<Course> courses = new List<Course>();
            
            List<Enrollment> enrollments = await _dbContext.Enrollment.Where(e => e.StudentId == studentId).ToListAsync();

            foreach (var enrollment in enrollments)
            {                            
                Course? Course =  await _dbContext.Courses.Where(c => c.Id == enrollment.CourseId).FirstOrDefaultAsync();
                if (Course != null)
                {
                    courses.Add(Course);
                }
            }
            return courses;
        }


    }
}
