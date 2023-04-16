using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class CourseUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course ToCourse()
        {
            Course course = new Course();

            course.Id = Id;
            course.Name = Name;
            return course;
        }
    }
}
