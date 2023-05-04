using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        //ToDo Name must be plural
        Task<IEnumerable<Course>> GetCourses();
        Task<Course?> GetCourseById(int id);
        Task<Course> CreateCourse(CourseCreateDTO courseDTO);
        Task<Course> UpdateCourse(CourseUpdateDTO courseDTO);
        Task<bool> DeleteCourse(int id);
        Task<bool> Exist(int id);
    }
}
