using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentsRepository _enrollmentsRepository;

        public CourseService(
            ICourseRepository courseRepository,
            IStudentRepository studentRepository,
            IEnrollmentsRepository enrollmentsRepository)
        {
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _enrollmentsRepository = enrollmentsRepository;

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

       
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseRepository.GetCourses();
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

        public async Task<Course> UpdateCourse(CourseUpdateDTO courseDTO)
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

        public async Task<bool> AssignStudent(EnrollmentCreateDTO enrollmentCreateDTO)
        {
            bool courseExists = await _courseRepository.Exist(enrollmentCreateDTO.CourseId);
            if (!courseExists)
            {
                throw new CustomValidationException("CourseId is invalid.");
            }

            bool studentExists = await _studentRepository.Exist(enrollmentCreateDTO.StudentId);
            if (!studentExists)
            {
                throw new CustomValidationException("StudentId is invalid.");
            }

            Enrollment enrollment = await _enrollmentsRepository.CreateEnrollment(enrollmentCreateDTO);

            if (enrollment != null)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Student>> GetCourseStudents(int courseId)
        {
            bool courseExists = await _courseRepository.Exist(courseId);
            if (!courseExists)
            {
                throw new CustomValidationException("CourseId is invalid.");
            }
            return await _studentRepository.GetStudentsByCourseId(courseId);
        }
    }
}

