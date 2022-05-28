namespace BlazorEcommerce.Client.Interfaces;

public interface IClientProductService
{
    List<Product> Products { get; set; }
    Task GetProducts();
}
