using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{

   
    public class PersonService : IPersonService
    {

        private readonly IBookRepository _bookRepository;
        private readonly IPersonRepository _personRepository;

        public PersonService(IBookRepository bookReposirory, IPersonRepository personRepository)
        {
            _bookRepository = bookReposirory;
            _personRepository = personRepository;
        }
              

        public Person CreatePerson(PersonCreateDTO personDTO)
        {
            Person person = personDTO.ToPerson();
            if (personDTO.Id <= 0)
            {
                throw new InvalidIdException();
            }
            return person;
           
        }

        public bool DeletePerson(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
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
