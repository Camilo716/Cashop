using cashop.core.Entities;
using cashop.core.interfaces;
using cashop.core.Services.ProductServices;
using cashop.infraestructure;
using cashop.infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace cashop.api;

public class Startup(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        Dependencies.ConfigureServices(_configuration, services);
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddScoped<PublicProductService>();
        services.AddScoped<IRepository<Product>, EfRepository<Product>>();
    }
    public void ConfigureMiddlewares(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoint => endpoint.MapControllers());
    }
}
