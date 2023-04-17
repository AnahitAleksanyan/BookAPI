namespace WebApplication4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
<<<<<<< HEAD

        public int Grade { get; set; }
        public List<Course> Courses { get; set; }
        
=======
        public int Grade { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();

>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
    }
}
