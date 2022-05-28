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
        //var products = new List<Product>()
        //{
        //    new Product
        //    {
        //        Id = 1,
        //        Title = "prod3",
        //        Description = "proddesc1",
        //        ImageUrl = "https://nerdist.com/wp-content/uploads/2021/04/Aliens-xenomorph.jpg",
        //        Price = 100
        //    },
        //            new Product
        //    {
        //        Id = 2,
        //        Title = "prod2",
        //        Description = "proddesc1",
        //        ImageUrl = "https://nerdist.com/wp-content/uploads/2021/04/Aliens-xenomorph.jpg",
        //        Price = 100
        //    }
        //};


        //var response = new ServiceResponse<List<Product>>()
        //{
        //    Data = products
        //};
        return Ok(response);
    }
}
