using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class CourseCreateDTO
    {
        public string Name { get; set; }

        public Course ToCourse()
        {
            Course course = new Course();
            course.Name = Name;
            return course;
        }
    }
}
