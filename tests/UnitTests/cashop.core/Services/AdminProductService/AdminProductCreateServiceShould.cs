using cashop.core.Services.ProductServices;
using cashop.core.Entities;
using cashop.core.interfaces;
using Moq;
using cashop.core.Exceptions;
using cashop.core.Validators;
using FluentValidation;


namespace UnitTests.cashop.core.Services;

public class AdminProductCreateServiceShould
{
    private readonly ICashopValidator<Product> _productCreationValidator;

    public AdminProductCreateServiceShould()
    {
        IValidator<Product> _productFluentValidator = new ProductCreationValidator();
        _productCreationValidator = new FluentValidatorAdapter<Product>(_productFluentValidator);
    }

    [Fact]
    public async Task CreateNewProduct()
    {
        Product product = new (){ Name = "T-Shirt" };
        var productService = new AdminProductService(GetMockRepository(product), _productCreationValidator);

        var productCreated = await productService.CreateProductAsync(product);

        Assert.IsAssignableFrom<Product>(productCreated);
        Assert.Equal("T-Shirt", productCreated.Name);
    }

    [Fact]
    public async Task CreateSecondProduct()
    {
        Product product = new (){ Name = "iPad" };
        Product product2 = new (){ Name = "iPhone" };
        var productService = new AdminProductService(GetMockRepository(product2), _productCreationValidator);
        _ = await productService.CreateProductAsync(product);

        var productCreated = await productService.CreateProductAsync(product2);

        Assert.IsAssignableFrom<Product>(productCreated);
        Assert.Equal("iPhone", productCreated.Name);
    }

    [Fact]
    public async Task DoesNotAllowCreatingProductsWithNegativePrice()
    {
        Product product = new (){ Name = "Headphones", Price = -1.0};
        var productService = new AdminProductService(GetMockRepository(product), _productCreationValidator);


        async Task createProductAction() => await productService.CreateProductAsync(product);

        await Assert.ThrowsAsync<NegativeProductPriceException>(createProductAction);
    }


    private IRepository<Product> GetMockRepository(Product product)
    {
        var mockRepository = new Mock<IRepository<Product>>();
        mockRepository.Setup(
            repo => repo
                .AddAsync(product, It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);

        return mockRepository.Object; 
    }
}