using WebApplication4.Models;

namespace WebApplication4.DTOs
{
    public class PersonCreateDTO
    {
        //ToDo In Create DTO we don't need Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person ToPerson()
        {
            Person person = new Person()
            {
                Age = this.Age,
                Name = this.Name,
                Surname = this.Surname,
            };

            return person;
        }
    }
}
