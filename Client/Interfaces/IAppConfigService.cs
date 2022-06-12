namespace BlazorEcommerce.Client.Interfaces;

public interface IAppConfigService
{
    ApplicationConfiguration AppConfig { get; set; }
    Task<ApplicationConfiguration> GetApplicationConfiguration();
}
