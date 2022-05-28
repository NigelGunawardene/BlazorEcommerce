namespace BlazorEcommerce.Server.Interfaces;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
}
