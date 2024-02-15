using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

public class ProgramTest
{
    private static readonly WebApplicationFactory<Program> _application = new();

    public static HttpClient NewClient
    {
        get
        {
            return _application.CreateClient();
        }
    }
}