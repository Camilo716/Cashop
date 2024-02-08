
using cashop.core.Entities;
using cashop.core.interfaces;

namespace cashop.core.Services.ProductServices;

public class AdminProductService(IRepository<Product> repository)
{
    private readonly IRepository<Product> repository = repository;

    public async Task<Product> CreateProductAsync(Product product)
    {
        return await repository.AddAsync(product);
    }
}