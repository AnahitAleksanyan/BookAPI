namespace WebApplication4.Models
{
    public class Course
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public string? Name { get; set; }
        public List<Student> Students { get; set; }
=======
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
    }
}
