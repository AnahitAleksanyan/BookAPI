using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Implementations;

namespace WebApplication4.Repositories.Implemetations
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SQLDBContext _dbContext;

        public StudentRepository(SQLDBContext context)
        {
             _dbContext = context;
        }

        public async  Task<Student> CreateStudent(StudentCreateDTO studentDTO)
        {
            var student = studentDTO.ToStudent();
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return student;      
        }

        public async  Task<bool> DeleteStudent(int id)
        {
            Student? student = _dbContext.Students.Where(student => student.Id == id).FirstOrDefault();
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task<bool> Exist(int id)
        {
           return  _dbContext.Students.AnyAsync(student => student.Id == id);
        }

        public async Task<IEnumerable<Student>> GetStudent()
        {
            var students = await _dbContext.Students.Where(_ => true).ToListAsync();
            return students;
        }
       
        public async Task<Student?> GetStudentById(int id)
        {
            var student = await _dbContext.Students.Where(student => student.Id == id).FirstOrDefaultAsync();
            return student;
        } 

        public async Task<Student> UpdateStudent(StudentUpdateDTO studentDTO)
        {
            Student? student = await GetStudentById(studentDTO.Id);
            if (student != null)
            {
                student.Name = studentDTO.Name;
                student.Surname = studentDTO.Surname;
                student.Age = studentDTO.Age;   
                await _dbContext.SaveChangesAsync();
                return student;
            }
            else
            {
                return studentDTO.ToStudent();
            }

        }
    }
}
