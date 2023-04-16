using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudent();
        Task<Student?> GetStudentById(int id);
        Task<Student> CreateStudent(StudentCreateDTO studentDTO);
        Task<Student> UpdateStudent(StudentUpdateDTO studentDTO);
        Task<bool> DeleteStudent(int id);
        
    }
}
