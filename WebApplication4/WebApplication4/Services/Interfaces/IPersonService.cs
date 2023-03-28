using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person?> GetPersonById(int id);
        Task<Person> CreatePerson(PersonCreateDTO personDTO);
        Task<Person> UpdatePerson(PersonUpdateDTO personDTO);
        Task<bool> DeletePerson(int id);
        Task<bool> Exists(int id);

    }
}
