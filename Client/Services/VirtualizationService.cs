using BlazorEcommerce.Client.Brokers.DataSources;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T> : IVirtualizationService<T>
{
    private readonly IDataSourceBroker<T> dataSourceBroker;
    private uint currentPageSize;
    private uint currentPosition;

    public VirtualizationService(IDataSourceBroker<T> dataSourceBroker) =>
        this.dataSourceBroker = dataSourceBroker;

    public IQueryable<T> LoadPage(uint startAt, uint pageSize) =>
    TryCatch(() =>
    {
        this.currentPosition = startAt;
        this.currentPageSize = pageSize;

        return this.dataSourceBroker.TakeSkip(startAt, pageSize);
    });

    public IQueryable<T> RetrieveNextPage() =>
    TryCatch(() =>
    {
        this.currentPosition += this.currentPageSize;

        return this.dataSourceBroker.TakeSkip(
            this.currentPosition,
            this.currentPageSize);
    });

    public uint GetCurrentPosition() =>
        this.currentPosition;

    public uint GetPageSize() =>
        this.currentPageSize;
}