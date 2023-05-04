namespace WebApplication4.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }  
        public Course Course { get; set; }  
    }
}