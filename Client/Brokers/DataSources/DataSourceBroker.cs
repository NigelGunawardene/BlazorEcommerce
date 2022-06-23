namespace BlazorEcommerce.Client.Brokers.DataSources;

public class DataSourceBroker<T> : IDataSourceBroker<T>
{
    private readonly IQueryable<T> dataSource;

    public DataSourceBroker(IQueryable<T> _dataSource)
    {
        dataSource = _dataSource;
    }
    public IQueryable<T> TakeAndSkip(int startAt, int pageSize) => this.dataSource.Skip(startAt).Take(pageSize);

}
