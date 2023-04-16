using System.Security;

namespace WebApplication4.Models
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Surname { get; set; }
        public  int Age { get; set; }
        public List<Book> Books { get; set; }
    }
}
