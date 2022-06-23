using BlazorEcommerce.Client.Brokers.DataSources;

namespace BlazorEcommerce.Client.Services;

public class VirtualizationService<T> : IVirtualizationService<T>
{
    private readonly IDataSourceBroker<T> dataSourceBroker;

    public VirtualizationService(IDataSourceBroker<T> _dataSourceBroker)
    {
        dataSourceBroker = _dataSourceBroker;
    }
    public IQueryable<T> LoadFirstPage(int startAt, int pageSize)
    {
        return this.dataSourceBroker.TakeAndSkip(startAt, pageSize);
    }
}
