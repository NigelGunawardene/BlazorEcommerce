namespace BlazorEcommerce.Client.Pages;

public partial class ProductList
{
    [Inject]
    private IClientProductService ProductService { get; set; }

    private static List<Product> Products = new List<Product>();

    protected override async Task OnInitializedAsync()
    {
        await ProductService.GetProducts();
        //var result = await Http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product");
        //Products = result.Data;
        //return base.OnInitializedAsync();
    }
}
