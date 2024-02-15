using cashop.core.Entities;
using cashop.core.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace cashop.api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly PublicProductService _productService;

    public ProductController(PublicProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<Product>> GetAsync()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }
}
