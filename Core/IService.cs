using Core.Models;

namespace Core;

public interface IService
{
    public IEnumerable<Person> GetAllPersons();
    public void AddPerson(Person person);
}