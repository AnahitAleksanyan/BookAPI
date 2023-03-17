using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IPersonService
    {
        public IEnumerable<Person> GetPeople();
        Person? GetPersonById(int id);
        Person CreatePerson(PersonCreateDTO personDTO);
        Person UpdatePerson(PersonUpdateDTO personDTO);
        bool DeletePerson(int id);
        bool Exists(int id);

    }
}
