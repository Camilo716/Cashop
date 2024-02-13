
using cashop.core.Entities;
using cashop.core.interfaces;
using cashop.core.Validators;
using FluentValidation;

namespace cashop.core.Services.ProductServices;

public class AdminProductService
{
    private readonly IRepository<Product> _repository;
    private readonly ICashopValidator<Product> _productValidator;

    public AdminProductService(IRepository<Product> repository, ICashopValidator<Product> productValidator)
    {
        _repository = repository;
        _productValidator = productValidator;
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        _productValidator.ValidateAndThrow(product);
        return await _repository.AddAsync(product);
    }
}