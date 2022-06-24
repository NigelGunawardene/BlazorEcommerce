namespace BlazorEcommerce.Client.Interfaces;

public interface IVirtualizationService<T>
{
    IQueryable<T> LoadPage(uint startAt, uint pageSize);
    IQueryable<T> RetrieveNextPage();
    uint GetCurrentPosition();
    uint GetPageSize();
}