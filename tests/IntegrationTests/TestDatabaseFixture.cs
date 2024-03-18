using cashop.infraestructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace IntegrationTests;

public class TestDatabaseFixture : IClassFixture<WebApplicationFactory<Program>>
{
    private string ConnectionString;
    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
        ConnectionString = GetConnectionString();

        lock (_lock)
        {
            if (!_databaseInitialized)
            {
                using var context = CreateContext();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            _databaseInitialized = true;
        }
    }

    private static string GetConnectionString()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

        return configuration.GetConnectionString("default-connection")!;
    }

    public CashopDbContext CreateContext()
        => new(
            new DbContextOptionsBuilder<CashopDbContext>()
                .UseSqlServer(ConnectionString)
                .Options
        );

}