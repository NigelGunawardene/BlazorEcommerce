namespace BlazorEcommerce.Client.Pages;
partial class ProductDetails
{
    [Inject]
    private IClientProductService ProductService { get; set; }

    public Product? product = null;

    [Parameter]
    public int Id { get; set; }
    private string message = string.Empty;


    protected override async Task OnParametersSetAsync()
    {
        message = "loading product..";
        var result = await ProductService.GetProductByIdAsync(Id);
        if (!result.Success)
        {
            message = result.Message;
        }
        else
        {
            product = result.Data;
        }
        //product = ProductService.Products.Find(p => p.Id == Id);
    }
}