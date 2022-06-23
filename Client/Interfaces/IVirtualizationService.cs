namespace BlazorEcommerce.Client.Interfaces;

public interface IVirtualizationService<T>
{
    IQueryable<T> LoadFirstPage(int startAt, int pageSize);
}
