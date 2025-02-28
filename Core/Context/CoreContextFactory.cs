using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Core.Context;

public class CoreContextFactory : IDesignTimeDbContextFactory<CoreContext>
{
    public string ConfigFileName { get; set; } = "appsettings.json";
    public CoreContext CreateDbContext(string[]? args)
    {
        IConfigurationRoot config;
        try
        {
            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(ConfigFileName)
                .Build();
        }
        catch (Exception e)
        {
            throw new ArgumentNullException($"Не удалось прочитать конфигурационный файл {ConfigFileName}.", e);
        }
        
        
        var connectionString = config.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentNullException("Строка подключения не может быть пустой.");
        }
        return new CoreContext(connectionString);
    }
}