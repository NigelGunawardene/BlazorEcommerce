namespace BlazorEcommerce.Client.Services;

public class AppConfigService : IAppConfigService
{
    private HttpClient _http;
    public ApplicationConfiguration? AppConfig { get; set; } = default;

    public AppConfigService(HttpClient http)
    {
        _http = http;
    }
    public async Task<ApplicationConfiguration> GetApplicationConfiguration()
    {
        var result = await _http.GetFromJsonAsync<ServiceResponse<ApplicationConfiguration>>("api/AppConfig");
        if (result != null && result.Data != null) AppConfig = result.Data;
        return AppConfig;
    }
}
