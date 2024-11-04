using Microsoft.AspNetCore.Mvc;
using Task2.Model;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<IEnumerable<Person>> GetAllPersons()
    {
        return await _personService.GetAllPersonsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetPersonById(int id)
    {
        var person = await _personService.GetPersonByIdAsync(id);
        if (person == null)
            return NotFound();
        return person;
    }

    [HttpPost]
    public async Task<ActionResult<Person>> AddPerson(Person person)
    {
        var newPerson = await _personService.AddPersonAsync(person);
        return CreatedAtAction(nameof(GetPersonById), new { id = newPerson.Id }, newPerson);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePerson(int id, Person person)
    {
        var updatedPerson = await _personService.UpdatePersonAsync(id, person);
        if (updatedPerson == null)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePerson(int id)
    {
        var success = await _personService.RemovePersonAsync(id);
        if (!success)
            return NotFound();
        return NoContent();
    }
}
