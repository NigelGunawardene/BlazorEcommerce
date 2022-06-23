namespace BlazorEcommerce.Client.Interfaces;

public interface IVirtualizationService<T>
{
    IQueryable<T> LoadFirstPage(uint startAt, uint pageSize);
}
