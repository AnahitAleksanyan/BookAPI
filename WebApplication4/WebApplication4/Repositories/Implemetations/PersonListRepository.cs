using Microsoft.AspNetCore.Mvc;
using WebApplication4.DTOs;
using WebApplication4.Exceptions;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

namespace WebApplication4.Repositories.Implemetations
{
    public class PersonListRepository : IPersonRepository
    {
        private readonly List<Person> people = new List<Person>
        {
            new Person()
            {
               Id = 1,
               Name = "Lusine",
               Surname = "Karapetyan",
               Age = 31
            },

             new Person()
            {
               Id =2,
               Name = "Arshak",
               Surname = "Sarafyan",
               Age = 9
            },

             new Person()
            {
               Id =3,
               Name = "Anna",
               Surname = "Karapetyan",
               Age = 39
            },

              new Person()
            {
               Id =4,
               Name = "Norayr",
               Surname = "Sarafyan",
               Age = 5
            }
        };

        public async Task<IEnumerable<Person>> GetPeople()
        {
            return people;
        }

        public async Task<Person?> GetPersonById(int Id)
        {
            bool Test(Person person)
            {
                return person.Id == Id;
            }

            var filteredList = people.Where(person => person.Id == Id);
            return filteredList.FirstOrDefault();
        }


        public async Task<Person> CreatePerson(PersonCreateDTO personDTO)
        {
            Person person = personDTO.ToPerson();

            int max = people[0].Id;
            foreach (Person item in people)
            {
                if (item.Id > max)
                {
                    max = item.Id;
                }
                person.Id = max + 1;
            }
            people.Add(person);
            return person;
        }

        public async Task<Person> UpdatePerson(PersonUpdateDTO personDTO)
        {
            Person? person = await  GetPersonById(personDTO.Id);
            if (person != null)
            {
                person.Name = personDTO.Name;
                person.Surname = personDTO.Surname;
                return person;
            }

            throw new InvalidIdException();

        }

        public async Task<bool> DeletePerson(int id)
        {
            Person? person = people.Where(Person => Person.Id == id).FirstOrDefault();
            if (person != null)
            {
               people.Remove(person);
                
                return true;
            }
            return false;

        }

        public async Task<bool> Exists(int id)
        {
           return  people.Any(person => person.Id == id);
            
        }
    }
}
