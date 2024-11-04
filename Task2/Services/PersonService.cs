using Microsoft.EntityFrameworkCore;
using Task2.Model;

public class PersonService : IPersonService
{
    private readonly AppDbContext _context;

    public PersonService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> GetAllPersonsAsync()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task<Person> GetPersonByIdAsync(int id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public async Task<Person> AddPersonAsync(Person person)
    {
        _context.Persons.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }

    public async Task<bool> RemovePersonAsync(int id)
    {
        var person = await GetPersonByIdAsync(id);
        if (person != null)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<Person> UpdatePersonAsync(int id, Person updatedPerson)
    {
        var person = await GetPersonByIdAsync(id);
        if (person != null)
        {
            person.Firstname = updatedPerson.Firstname;
            person.Lastname = updatedPerson.Lastname;
            person.Age = updatedPerson.Age;
            await _context.SaveChangesAsync();
            return person;
        }
        return null;
    }
}
