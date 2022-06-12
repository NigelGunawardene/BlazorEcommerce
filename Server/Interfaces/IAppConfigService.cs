namespace BlazorEcommerce.Server.Interfaces;

public interface IAppConfigService
{
    Task<ServiceResponse<ApplicationConfiguration>> GetAppConfigAsync();
}
