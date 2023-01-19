namespace BlazorEcommerce.Client.Interfaces;

public interface IClientProductService
{
    List<Product> Products { get; set; }
    Task GetProductsAsync();

    Task<ServiceResponse<Product>> GetProductByIdAsync(int productId);
    Task<int> GetProductsCountAsync();
    Task<ServiceResponse<ICollection<Product>>> GetPaginatedProductsAsync(int startIndex, int pageSize);
}
