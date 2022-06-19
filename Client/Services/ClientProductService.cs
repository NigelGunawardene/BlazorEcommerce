namespace BlazorEcommerce.Client.Services;

public class ClientProductService : IClientProductService
{
    private HttpClient _http;
    public List<Product> Products { get; set; } = new List<Product>();


    public ClientProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task GetProducts()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        if (result != null && result.Data != null) Products = result.Data;
    }

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/Product/{productId}");
        return result;
    }
}
