using BlazorEcommerce.Client.Brokers.DataSources;
using BlazorEcommerce.Shared.Exceptions;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T> : IVirtualizationService<T>
{

    private uint position { get; set; }
    private uint currentPageSize { get; set; }
    private readonly IDataSourceBroker<T> dataSourceBroker;


    public VirtualizationService(IDataSourceBroker<T> _dataSourceBroker)
    {
        dataSourceBroker = _dataSourceBroker;
    }
    public IQueryable<T> LoadFirstPage(uint position, uint pageSize) =>
        TryCatch(() =>
        {
            this.currentPageSize = pageSize;

            return this.dataSourceBroker.TakeSkip(position, pageSize);
        });

    public uint GetPageSize() => this.currentPageSize;

}
