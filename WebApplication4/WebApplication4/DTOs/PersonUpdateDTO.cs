using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class PersonUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Person ToPerson()
        {
            Person person = new Person()
            {
                Id = this.Id,
                Name = this.Name,
                Surname = this.Surname,
            };

            return person;
        }
    }
}
