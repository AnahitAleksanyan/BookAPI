using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeople();
        Person? GetPersonById(int id);
        Person CreatePerson(PersonCreateDTO personDTO);
        Person UpdatePerson(PersonUpdateDTO personDTO);
        bool DeletePerson(int id);
    }
}
