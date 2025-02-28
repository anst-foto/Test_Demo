using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Context;

public class CoreContext : DbContext
{
    private readonly string _connectionString;
    
    public DbSet<Person> Persons { get; set; }

    public CoreContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString);
    }
}