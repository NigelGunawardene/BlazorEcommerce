namespace BlazorEcommerce.Client.Brokers.DataSources;

public interface IDataSourceBroker<T>
{
    public IQueryable<T> TakeAndSkip(int startAt, int pageSize);
}
