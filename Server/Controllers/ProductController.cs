using BlazorEcommerce.Shared.Entities;
using BlazorEcommerce.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts() //IActionResult
    {
        var response = await _productService.GetProductsAsync();
        return Ok(response);
    }


    [HttpGet("Paginated")]
    public async Task<ActionResult<ServiceResponse<ICollection<Product>>>> GetPaginatedProducts(int startIndex, int pageSize) //IActionResult
    {
        var response = await _productService.GetPaginatedProductsAsync(startIndex, pageSize);
        return Ok(response);
    }



    [HttpGet("{productId}")]
    //[Route("{productId}")]
    public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId) //IActionResult
    {
        var response = await _productService.GetProductAsync(productId);
        return Ok(response);
    }
}
