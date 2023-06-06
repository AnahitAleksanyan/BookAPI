namespace WebApplication4.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student> Students { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
