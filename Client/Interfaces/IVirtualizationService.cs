namespace BlazorEcommerce.Client.Interfaces;

public interface IVirtualizationService<T>
{
    IQueryable<T> LoadFirstPage(uint position, uint pageSize);
    uint GetPageSize();
}
