using System.Security;

namespace WebApplication4.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Surname { get; set; }
        public  int Age { get; set; }
<<<<<<< HEAD
        public List<Book> Books { get; set; }
=======
        public List<Book> Books { get; set; } = new List<Book>();
>>>>>>> 45a8ea0203466428adc0a1db1750dfb0174e37f2
    }
}
