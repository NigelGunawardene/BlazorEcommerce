using BlazorEcommerce.Client.Brokers.DataSources;
using BlazorEcommerce.Shared.Exceptions;

namespace BlazorEcommerce.Client.Services;

public class VirtualizationService<T> : IVirtualizationService<T>
{
    private readonly IDataSourceBroker<T> dataSourceBroker;

    public VirtualizationService(IDataSourceBroker<T> _dataSourceBroker)
    {
        dataSourceBroker = _dataSourceBroker;
    }
    public IQueryable<T> LoadFirstPage(uint startAt, uint pageSize)
    {
        try
        {
            return this.dataSourceBroker.TakeSkip(startAt, pageSize);
        }
        catch (Exception ex)
        {
            VirtualizationServiceException virtualizationServiceException = new VirtualizationServiceException(ex);
            throw virtualizationServiceException;
        }
    }
}
