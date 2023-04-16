using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetCourse();
        Task<Course?> GetCourseById(int id);
        Task<Course> CreateCourse(CourseCreateDTO courseDTO);
        Task<Course> UpdateCourse(CourseUpdateDTO courseDTO);
        Task<bool> DeleteCourse(int id);       
    }
}
