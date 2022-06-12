namespace BlazorEcommerce.Client.Store.Actions;

public class SetAppConfigAction
{
    //private IAppConfigService _appConfigService;

    public ApplicationConfiguration AppConfig { get; }

    public SetAppConfigAction(ApplicationConfiguration config)
    {
        AppConfig = config;
    }
    //public SetAppConfigAction(IAppConfigService appConfigService)
    //{
    //    _appConfigService = appConfigService;
    //    AppConfig = GetAppConfigFromDb().Result;
    //}

    //private async Task<ApplicationConfiguration> GetAppConfigFromDb()
    //{
    //    var appConfigFromDb = await _appConfigService.GetApplicationConfiguration();
    //    return appConfigFromDb;
    //}
}
