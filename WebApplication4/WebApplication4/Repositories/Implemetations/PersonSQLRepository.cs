using Microsoft.EntityFrameworkCore;
using System;
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
        _dbContext.Add(person);
        await _dbContext.SaveChangesAsync();
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
        var books = await _dbContext.People.Where(_ => true).ToListAsync();
        return books;
    }

    public async Task<Person?> GetPersonById(int id)
    {
        return await _dbContext.People.Where(person => person.Id == id).FirstOrDefaultAsync();

    }

    public async Task<Person> UpdatePerson(PersonUpdateDTO personDTO)
    {
        Person? existingPerson = await GetPersonById(personDTO.Id);
        if (existingPerson != null)
        {
            existingPerson.Name = personDTO.Name;
            existingPerson.Surname = personDTO.Surname;
            await _dbContext.SaveChangesAsync();
            return existingPerson;
        }

        return personDTO.ToPerson();
    }

}