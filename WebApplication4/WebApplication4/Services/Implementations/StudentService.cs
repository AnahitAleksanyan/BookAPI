using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Implemetations;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> CreateStudent(StudentCreateDTO studentDTO)
        {
            if (studentDTO.Name == null || studentDTO.Name.Length < 3)
            {
                throw new CustomValidationException("Student Name must has at least 3 character");
            }
            if (studentDTO.Age < 1 && studentDTO.Age > 120)
            {
                throw new CustomValidationException("Student Age is invalid");
            }
            return await _studentRepository.CreateStudent(studentDTO);
            
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _studentRepository.DeleteStudent(id);
        }

       
        public async Task<IEnumerable<Student>> GetStudent()
        {
            return await _studentRepository.GetStudent();
        }

        public Task<Student?> GetStudentById(int id)
        {
            var result = _studentRepository.GetStudentById(id);
            if (result == null)
            {
                throw new InvalidIdException();
            }
            return result;
        }

        public async  Task<Student> UpdateStudent(StudentUpdateDTO studentDTO)
        {
            var exists = await _studentRepository.Exist(studentDTO.Id);
            if (!exists)
            {
                throw new CustomValidationException("The student not exist");
            }
            if (studentDTO.Name == null || studentDTO.Name.Length < 3)
            {
                throw new CustomValidationException("student Name has at least 3 charachter");
            }
            if (studentDTO.Age < 1 && studentDTO.Age > 120)
            {
                throw new CustomValidationException("the student age is a invalid");
            }
            return await  _studentRepository.UpdateStudent(studentDTO);
        }
    }

        
}
