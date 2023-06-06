using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class StudentUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        
        public Student ToStudent()
        {
            Student student = new Student();
            student.Id = Id;
            student.Name = Name;    
            student.Surname = Surname;
            student.Age = Age;
            return student;
        }
    }
}
