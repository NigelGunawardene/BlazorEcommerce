namespace BlazorEcommerce.Server.Services;

public class ProductService : IProductService
{
    private readonly ApplicationContext _context;

    public ProductService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Message = "All Products",
            Success = true,
            Data = await _context.Products.ToListAsync()
        };
        return response;
    }
    public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
    {
        var response = new ServiceResponse<Product>();
        var product = await _context.Products.FindAsync(productId);

        if (product == null)
        {
            response.Success = false;
            response.Message = "Product not found";
        }

        if (product != null)
        {
            response.Success = true;
            response.Message = "Done";
            response.Data = product;
        }

        return response;
    }

    public async Task<ServiceResponse<ICollection<Product>>> GetPaginatedProductsAsync(int startIndex, int pageSize)
    {
        var response = new ServiceResponse<ICollection<Product>>();
        response.Message = $"{startIndex} {pageSize}";
        response.Data = await _context.Products.Skip(startIndex).Take(pageSize).OrderBy(product => product.Id).ToListAsync();
        response.Success = true;
        //response.
        return response;

    }
}
