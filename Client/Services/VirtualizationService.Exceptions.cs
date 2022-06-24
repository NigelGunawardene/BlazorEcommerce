using BlazorEcommerce.Shared.Exceptions;

namespace BlazorEcommerce.Client.Services;

public partial class VirtualizationService<T>
{
    private delegate IQueryable<T> ReturningQueryableFunction();

    private IQueryable<T> TryCatch(ReturningQueryableFunction returningQueryableFunction)
    {
        try
        {
            return returningQueryableFunction();
        }
        catch (Exception exception)
        {
            var virtualizationServiceException =
                new VirtualizationServiceException(exception);

            throw virtualizationServiceException;
        }
    }
}

