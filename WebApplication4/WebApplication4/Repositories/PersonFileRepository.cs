using WebApplication4.DTOs;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public class PersonFileRepository : IPersonRepository
    {
        public Person CreatePerson(PersonCreateDTO personDTO)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Person? GetPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Person UpdatePerson(PersonUpdateDTO personDTO)
        {
            throw new NotImplementedException();
        }
    }
}
