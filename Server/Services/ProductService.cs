using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerce.Server.Services;

public class ProductService : IProductService
{
    private readonly BlazorEcommerceContext _context;

    public ProductService(BlazorEcommerceContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Message = "working",
            Success = true,
            Data = await _context.Products.ToListAsync()
        };
        return response;
    }
}
