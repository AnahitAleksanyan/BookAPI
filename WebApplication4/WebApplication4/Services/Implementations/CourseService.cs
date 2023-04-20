using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Implemetations;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;

        }
        public async Task<Course> CreateCourse(CourseCreateDTO courseDTO)
        {
            if (courseDTO.Name == null || courseDTO.Name.Length < 2)
            {
                throw new CustomValidationException("Course name must has at least 2 character");
            }


            return await _courseRepository.CreateCourse(courseDTO);
            
        }

        public async Task<bool> DeleteCourse(int id)
        {
            return await _courseRepository.DeleteCourse(id);
        }

        //ToDo Name must be plural
        public async Task<IEnumerable<Course>> GetCourse()
        {
            return await _courseRepository.GetCourse();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            var result = await _courseRepository.GetCourseById(id);

            if (result == null)
            {
                throw new InvalidIdException();
            }

            return result;
        }

        public async  Task<Course> UpdateCourse(CourseUpdateDTO courseDTO)
        {
            var exists = await _courseRepository.Exist(courseDTO.Id);
            if (!exists)
            {
                throw new CustomValidationException("the course is not exist");
            }

            if (courseDTO.Name == null || courseDTO.Name.Length < 2)
            {
                throw new CustomValidationException("Invalid name");
            }                  
           return await _courseRepository.UpdateCourse(courseDTO);
        }
    }
}

