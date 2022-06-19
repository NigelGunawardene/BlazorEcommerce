namespace BlazorEcommerce.Client.Pages;
partial class ProductDetails
{
    [Inject]
    private IClientProductService ProductService { get; set; }

    public Product product = null;

    [Parameter]
    public int Id { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        product = ProductService.Products.Find(p => p.Id == Id);
    }
}