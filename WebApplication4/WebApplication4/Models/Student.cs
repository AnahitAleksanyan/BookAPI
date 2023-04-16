namespace WebApplication4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public int Grade { get; set; }
        public List<Course> Courses { get; set; }
        
    }
}
