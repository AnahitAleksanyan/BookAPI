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

        public PersonService(IBookRepository bookRepository, IPersonRepository personRepository)
        {
            _bookRepository = bookRepository;
            _personRepository = personRepository;
        }
            
        private void ValidateNameAndSurname(in string name, in string surname)
        {
            if (name == null || name.Length < 2)
            {
                throw new CustomValidationException("invalid Name");
            }

            if (surname == null || surname.Length < 3)
            {
                throw new CustomValidationException("Invalid Surname");
            }

        }

        public async Task<Person> CreatePerson(PersonCreateDTO personDTO)
        {
            ValidateNameAndSurname(personDTO.Name, personDTO.Surname);
            
            if (personDTO.Age < 5 || personDTO.Age > 100)
            {
                throw new CustomValidationException("invalid Age");
            }

            Person person =  personDTO.ToPerson();
            return person;
        }

        public async Task<Person> UpdatePerson(PersonUpdateDTO personDTO)
        {
            if (personDTO.Id <= 0 )
            {
                throw new InvalidIdException();
            }
            ValidateNameAndSurname(personDTO.Name, personDTO.Surname);

            Person person = personDTO.ToPerson();
            return person;
        }

        public async Task<bool> DeletePerson(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
            else
            {
                await _personRepository.DeletePerson(id);

                return true;

            }
        }

        public async Task<bool> Exists(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
            else
            {
                await _personRepository.Exists(id);
                return true;
            }
           
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
           return await _personRepository.GetPeople();
        }

        public async Task<Person?> GetPersonById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidIdException();
            }
            else
            {
               await  _personRepository.GetPersonById(id);
            }
            return null;
        }

       
    }
}
