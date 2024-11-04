using Task2.Model;

public interface IPersonService
{
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Task<Person> GetPersonByIdAsync(int id);
    Task<Person> AddPersonAsync(Person person);
    Task<bool> RemovePersonAsync(int id);
    Task<Person> UpdatePersonAsync(int id, Person updatedPerson);
}
