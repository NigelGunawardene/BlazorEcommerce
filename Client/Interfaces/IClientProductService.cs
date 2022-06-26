namespace BlazorEcommerce.Client.Interfaces;

public interface IClientProductService
{
    List<Product> Products { get; set; }
    Task GetProducts();

    Task<ServiceResponse<Product>> GetProduct(int productId);
    Task<ServiceResponse<ICollection<Product>>> GetPaginatedProducts(int startIndex, int pageSize);
}
