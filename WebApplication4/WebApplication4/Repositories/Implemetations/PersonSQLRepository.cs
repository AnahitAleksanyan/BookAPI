using Microsoft.EntityFrameworkCore;
using WebApplication4.DTOs;
using WebApplication4.Models;
using WebApplication4.Repositories.Interfaces;

public class PersonSQLRepository : IPersonRepository
{
    private readonly SQLDBContext _dbContext;

    public PersonSQLRepository(SQLDBContext context)
    {
        _dbContext = context;
    }
    public async Task<Person> CreatePerson(PersonCreateDTO personDTO)
    {
        Person person = personDTO.ToPerson();
        //ToDo use method Add instead of AddAync and call save changes after that
        await _dbContext.People.AddAsync(person);

        return person;

    }

    public async Task<bool> DeletePerson(int id)
    {
        Person? person = await GetPersonById(id);
        if (person != null)
        {
            _dbContext.People.Remove(person);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> Exists(int id)
    {
        return await _dbContext.People.AnyAsync(person => person.Id == id);
    }

    public async Task<IEnumerable<Person>> GetPeople()
    {
        //ToDo use where operator to get all people _=> true
        return _dbContext.People;  // stex harc unim

    }

    public async Task<Person?> GetPersonById(int id)
    {
        return await _dbContext.People.Where(person => person.Id == id).FirstOrDefaultAsync();

    }

    public async Task<Person> UpdatePerson(PersonUpdateDTO personDTO)
    {
        //ToDo first you need to get existing person by personDTO.Id , and then change it's fields
        Person person = personDTO.ToPerson();

        person.Name = personDTO.Name;
        person.Surname = personDTO.Surname;
        await _dbContext.SaveChangesAsync();

        return person;

    }
}
