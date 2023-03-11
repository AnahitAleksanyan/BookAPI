using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
namespace WebApplication4.Repositories
{
    public class PersonRepository
    {

        private readonly List<Person> people = new List<Person>
        {
            new Person()
            {
               Id = 1,
               Name = "Lsine",
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

        public IEnumerable<Person> GetPerson()
        {
            return people;
        }

        public Person? GetPersonById(int Id)
        {
            return people.Where(Person => Person.Id == Id).FirstOrDefault();
        }

        public Person CreatePerson(Person person)
        {
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

        public bool DeletePerson(int id)
        {
            Person? person = people.Where(Person => Person.Id == id).FirstOrDefault();
            if (person != null)
            {
                people.Remove(person);
                return true;
            }
            return false;

        }

        internal ActionResult<IEnumerable<Person>> GetPersonById()
        {
            throw new NotImplementedException();
        }
    }
}
