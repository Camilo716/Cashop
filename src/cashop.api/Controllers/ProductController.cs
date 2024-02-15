using cashop.core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace cashop.api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    public ProductController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<Product>> GetAsync()
    {
        return Ok();
    }
}
