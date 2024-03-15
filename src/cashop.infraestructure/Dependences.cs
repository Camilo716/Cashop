using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace cashop.infraestructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        services.AddDbContext<CashopDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("default-connection")));
    }
}