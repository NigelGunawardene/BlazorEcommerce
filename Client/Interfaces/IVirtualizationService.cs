namespace BlazorEcommerce.Client.Interfaces;

public interface IVirtualizationService<T>
{
    IQueryable<T> LoadFirstPage(uint position, uint pageSize);
    IQueryable<T> RetrieveNextPage();
    uint GetCurrentPosition();
    uint GetPageSize();
}
