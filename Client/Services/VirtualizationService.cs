using BlazorEcommerce.Client.Brokers.DataSources;
using BlazorEcommerce.Shared.Exceptions;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T> : IVirtualizationService<T>
{

    //public uint StartAt { get; set; }
    //public uint pageSize { get; set; }

    private readonly IDataSourceBroker<T> dataSourceBroker;

    public VirtualizationService(IDataSourceBroker<T> _dataSourceBroker)
    {
        dataSourceBroker = _dataSourceBroker;
    }
    public IQueryable<T> LoadFirstPage(uint startAt, uint pageSize) =>
        TryCatch(() =>
        {
            return this.dataSourceBroker.TakeSkip(startAt, pageSize);
        });
}
