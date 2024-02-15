namespace IntegrationTests.ProductEndpoints;

public class ProductGetEndpointTest
{
    [Fact]
    public async Task GetAllProducts()
    {
        var response = await ProgramTest.NewClient.GetAsync("api/products");

        response.EnsureSuccessStatusCode();
    }
}