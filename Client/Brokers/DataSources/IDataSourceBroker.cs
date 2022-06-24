namespace BlazorEcommerce.Client.Brokers.DataSources;

public interface IDataSourceBroker<T>
{
    public IQueryable<T> TakeSkip(uint position, uint pageSize);
}
