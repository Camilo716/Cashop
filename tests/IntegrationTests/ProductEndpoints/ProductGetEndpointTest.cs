namespace IntegrationTests.ProductEndpoints;

public class ProductGetEndpointTest : IClassFixture<TestDatabaseFixture>
{
    private readonly TestDatabaseFixture _fixture;

    public ProductGetEndpointTest(TestDatabaseFixture testDatabaseFixture)
    {
        _fixture = testDatabaseFixture;
    }

    [Fact]
    public async Task GetAllProducts()
    {
        using var context = _fixture.CreateContext();
        var response = await ProgramTest.NewClient.GetAsync("api/product");

        response.EnsureSuccessStatusCode();
    }
}