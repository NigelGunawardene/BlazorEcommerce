using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BlazorEcommerce.Client.Pages;

public partial class ProductList
{
    [Inject]
    private IClientProductService ProductService { get; set; }

    private static List<Product> Products = new List<Product>();

    private int totalCount = 1000;


    [Parameter]
    public EventCallback<Product> OnScroll { get; set; }

    protected override async Task OnInitializedAsync()
    {
        totalCount = await ProductService.GetProductsCountAsync();
        //await ProductService.GetProducts(); // UNCOMMENT THIS LATER
        //var result = await ProductService.GetPaginatedProducts(0, 100);
        //Products = result.Data.ToList();


        //var result = await Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        //Products = result.Data;
        //return base.OnInitializedAsync();
    }

    private async ValueTask<ItemsProviderResult<Product>> LoadVisibleProducts(ItemsProviderRequest request)
    {
        var numEmployees = Math.Min(request.Count, totalCount - request.StartIndex);
        var result = await ProductService.GetPaginatedProductsAsync(request.StartIndex, numEmployees);
        //totalCount = result.TotalCount;
        return new ItemsProviderResult<Product>(result.Data, result.TotalCount);
    }

    //private async Task<ICollection<Product>?> TestLoad()
    //{
    //    var numProducts = Math.Min(10, 10000);
    //    var result = await ProductService.GetPaginatedProducts(0, 10);
    //    Products = result.Data.ToList();
    //    return result.Data;
    //}
}
