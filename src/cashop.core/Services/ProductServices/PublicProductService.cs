using cashop.core.Entities;
using cashop.core.interfaces;

namespace cashop.core.Services.ProductServices;

public class PublicProductService
{
    private readonly IRepository<Product> _repository;

    public PublicProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _repository.ListAsync();
    }
}