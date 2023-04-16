using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class StudentCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public int Grade { get; set; }
       

        public Student ToStudent()
        {
            Student student = new Student();    
            student.Name = Name;
            student.Surname = Surname;
            student.Age = Age;
            student.Grade = Grade;  
            return student; 
        }
    }
}
