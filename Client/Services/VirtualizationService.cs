using BlazorEcommerce.Client.Brokers.DataSources;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T> : IVirtualizationService<T>
{

    private uint currentPosition { get; set; }
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

    public IQueryable<T> RetrieveNextPage()
    {
        this.currentPosition += this.currentPageSize;
        return this.dataSourceBroker.TakeSkip(currentPosition, currentPageSize);
    }

    public uint GetCurrentPosition() => this.currentPosition;

    public uint GetPageSize() => this.currentPageSize;

}
