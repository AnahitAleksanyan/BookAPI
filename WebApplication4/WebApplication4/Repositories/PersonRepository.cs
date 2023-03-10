using WebApplication4.Models;
namespace WebApplication4.Repositories
{
    public class PersonRepository
    {

        private readonly List<Person> people = new List<Person>
        {
            new Person()
            {
               Id =1,
               Name = "Lsine",
               Surname = "Karapetyan",
               Age = 31
            },

             new Person()
            {
               Id =2,
               Name = "Arshak",
               Surname = "Sarafyan",
               Age =9
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

        public Person? GetePersonById(int Id)
        {
            return people.Where(person => person.Id == Id).FirstOrDefault();
        }

        



    }
}
