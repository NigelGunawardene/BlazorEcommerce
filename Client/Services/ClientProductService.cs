using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BlazorEcommerce.Client.Services;

public class ClientProductService : IClientProductService
{
    private HttpClient _http;
    public List<Product> Products { get; set; } = new List<Product>();


    public ClientProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProductsAsync()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        if (result != null && result.Data != null) Products = result.Data;
    }

    public async Task<ServiceResponse<Product>> GetProductByIdAsync(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
        return result;
    }

    public async Task<ServiceResponse<ICollection<Product>>> GetPaginatedProductsAsync(int startIndex, int pageSize)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<ICollection<Product>>>($"api/Product/Paginated?startIndex={startIndex}&pageSize={pageSize}");
        Products = result.Data.ToList();
        return result;
    }

    public async Task<int> GetProductsCountAsync()
    {
        var result = await _http.GetFromJsonAsync<int>("api/Product/Count");
        return result;
    }

    //public async ValueTask<ItemsProviderResult<Product>> GetPaginatedProducts(ItemsProviderRequest request)
    //{
    //    Console.WriteLine($"{request.StartIndex} {request.Count}");
    //    return new ItemsProviderResult<Product>(new List<Product>(), 10);
    //}
}
