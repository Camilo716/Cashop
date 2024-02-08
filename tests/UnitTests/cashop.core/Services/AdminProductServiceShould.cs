using cashop.core.Services.ProductServices;
using cashop.core.Entities;
using cashop.core.interfaces;
using Moq;


namespace UnitTests.cashop.core.Services;

public class AdminProductServiceShould
{
    [Fact]
    public async Task CreateNewProduct()
    {
        Product product = new (){ Description = "T-Shirt" };
        var productService = new AdminProductService(CreateMockRepository(product));

        var productCreated = await productService.CreateProductAsync(product);

        Assert.IsAssignableFrom<Product>(productCreated);
        Assert.Equal("T-Shirt", productCreated.Description);
    }

    [Fact]
    public async Task CreateSecondProduct()
    {
        Product product = new (){ Description = "iPad" };
        Product product2 = new (){ Description = "iPhone" };
        var productService = new AdminProductService(CreateMockRepository(product2));
        _ = await productService.CreateProductAsync(product);

        var productCreated = await productService.CreateProductAsync(product2);

        Assert.IsAssignableFrom<Product>(productCreated);
        Assert.Equal("iPhone", productCreated.Description);
    }

    private IRepository<Product> CreateMockRepository(Product product)
    {
        var mockRepository = new Mock<IRepository<Product>>();
        mockRepository.Setup(
            repo => repo
                .AddAsync(product, It.IsAny<CancellationToken>()))
                .ReturnsAsync(product);

        return mockRepository.Object; 
    }
}