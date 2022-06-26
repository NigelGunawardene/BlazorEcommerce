using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BlazorEcommerce.Client.Pages;

public partial class ProductList
{
    [Inject]
    private IClientProductService ProductService { get; set; }

    private static List<Product> Products = new List<Product>();

    protected override async Task OnInitializedAsync()
    {
        //await ProductService.GetProducts(); // UNCOMMENT THIS LATER
        var result = await ProductService.GetPaginatedProducts(0, 100);
        Products = result.Data.ToList();


        //var result = await Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        //Products = result.Data;
        //return base.OnInitializedAsync();
    }

    private async ValueTask<ItemsProviderResult<Product>> LoadVisibleProducts(ItemsProviderRequest request)
    {
        var numProducts = Math.Min(request.Count, 10000 - request.StartIndex); //var numEmployees = Math.Min(request.Count, totalEmployees - request.StartIndex);
        var result = await ProductService.GetPaginatedProducts(request.StartIndex, 40);
        return new ItemsProviderResult<Product>(result.Data, result.Data.Count);
    }

    private async Task<ICollection<Product>?> TestLoad()
    {
        var numProducts = Math.Min(10, 10000);
        var result = await ProductService.GetPaginatedProducts(0, 10);
        Products = result.Data.ToList();
        return result.Data;
    }
}
