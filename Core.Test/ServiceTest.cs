using Core.Models;

namespace Core.Test;

public class ServiceTest
{
    [Fact]
    public void ServiceCreate_PositiveTest()
    {
        var service = new Service("test_appsettings.json");
        
        //Assert.NotEqual(null, service);
        Assert.NotNull(service);
    }

    [Fact]
    public void ServiceCreate_NegativeTest()
    {
        Assert.Multiple(
            () => Assert.Throws<ArgumentNullException>(() => new Service("")),
            () => Assert.Throws<ArgumentNullException>(() => new Service("bad_appsettings.json"))
            );
    }

    [Fact]
    public void GetAllPersons_PositiveTest()
    {
        var expected = new List<Person>()
        {
            new()
            {
                Id = new Guid("8d2c66dc-37ee-478a-9642-cd88ff250e44"),
                LastName = "Starinin",
                FirstName = "Andrey"
            },
            new()
            {
                Id = new Guid("fbfd87bd-0a98-4b5c-b81c-7a573f641307"),
                LastName = "Ivanov",
                FirstName = "Ivan"
            }
        };
        
        var service = new Service("test_appsettings.json");
        var actual = service.GetAllPersons();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AddPerson_PositiveTest()
    {
        var expected = new List<Person>()
        {
            new()
            {
                Id = new Guid("8d2c66dc-37ee-478a-9642-cd88ff250e44"),
                LastName = "Starinin",
                FirstName = "Andrey"
            },
            new()
            {
                Id = new Guid("fbfd87bd-0a98-4b5c-b81c-7a573f641307"),
                LastName = "Ivanov",
                FirstName = "Ivan"
            },
            new()
            {
                Id = new Guid("8d2c66dc-37ee-478a-9642-cd88ff250e44"),
                LastName = "Petrov",
                FirstName = "Petr"
            }
        };
        
        var service = new Service("test_appsettings.json");
        service.AddPerson(new Person() { LastName = "Petrov", FirstName = "Petr" });
        var actual = service.GetAllPersons();
        
        Assert.Equal(expected, actual);
    }
}