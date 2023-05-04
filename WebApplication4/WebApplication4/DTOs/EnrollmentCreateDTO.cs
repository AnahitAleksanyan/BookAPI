using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class EnrollmentCreateDTO
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Enrollment ToEnrollment()
        {
            return new Enrollment()
            {
                CourseId = this.CourseId,
                StudentId = this.StudentId
            };
        }
    }
}
