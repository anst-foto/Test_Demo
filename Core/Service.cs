using Core.Context;
using Core.Models;

namespace Core;

public class Service : IService
{
    private readonly CoreContext _context;

    public Service(string configFileName)
    {
        var configFactory = new CoreContextFactory()
        {
            ConfigFileName = configFileName
        };
        _context = configFactory.CreateDbContext(null);
    }
    
    public IEnumerable<Person> GetAllPersons() => _context.Persons;

    public void AddPerson(Person person)
    {
        _context.Persons.Add(person);
        _context.SaveChanges();
    }
}