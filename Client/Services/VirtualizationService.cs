using BlazorEcommerce.Client.Brokers.DataSources;
using BlazorEcommerce.Shared.Exceptions;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T> : IVirtualizationService<T>
{

    private uint StartAt { get; set; }
    private uint currentPageSize { get; set; }
    private readonly IDataSourceBroker<T> dataSourceBroker;


    public VirtualizationService(IDataSourceBroker<T> _dataSourceBroker)
    {
        dataSourceBroker = _dataSourceBroker;
    }
    public IQueryable<T> LoadFirstPage(uint startAt, uint pageSize) =>
        TryCatch(() =>
        {
            this.currentPageSize = pageSize;

            return this.dataSourceBroker.TakeSkip(startAt, pageSize);
        });

    public uint GetPageSize() => this.currentPageSize;

}
