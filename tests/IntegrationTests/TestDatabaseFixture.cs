using cashop.infraestructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegrationTests;

public class TestDatabaseFixture : IClassFixture<WebApplicationFactory<Program>>
{
    private const string ConnectionString = "Host=172.17.0.2;Port=1433;Database=cashop;Username=SA;Password=Mysecretpassword*;Trusted_Connection=True";
    private static readonly object _lock = new();
    private static bool _databaseInitialized;

    public TestDatabaseFixture()
    {
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

    public CashopDbContext CreateContext()
        => new(
            new DbContextOptionsBuilder<CashopDbContext>()
                .UseSqlServer(ConnectionString)
                .Options
        );

}