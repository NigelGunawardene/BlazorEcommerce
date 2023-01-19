namespace BlazorEcommerce.Server.Interfaces;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
    Task<int> GetProductsCountAsync();
    Task<ServiceResponse<Product>> GetProductAsync(int productId);
    Task<ServiceResponse<ICollection<Product>>> GetPaginatedProductsAsync(int startIndex, int pageSize);
}
