using BlazorEcommerce.Shared.Exceptions;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T>
{
    private delegate IQueryable<T> ReturningQueryableFunction<T>();

    private IQueryable<T> TryCatch(ReturningQueryableFunction<T> returningQueryableFunction)
    {
        try
        {
            return returningQueryableFunction();
        }
        catch (Exception ex)
        {
            VirtualizationServiceException virtualizationServiceException = new VirtualizationServiceException(ex);
            throw virtualizationServiceException;
        }
    }
}

