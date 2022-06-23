namespace BlazorEcommerce.Client.Brokers.DataSources;

public class DataSourceBroker<T> : IDataSourceBroker<T>
{
    private readonly IQueryable<T> dataSource;

    public DataSourceBroker(IQueryable<T> _dataSource)
    {
        dataSource = _dataSource;
    }
    public IQueryable<T> TakeSkip(uint startAt, uint pageSize) => this.dataSource.Skip((int)startAt).Take((int)pageSize);

}
