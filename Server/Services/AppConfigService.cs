

namespace BlazorEcommerce.Server.Services;

public class AppConfigService : IAppConfigService
{
    private ApplicationContext _context;

    public AppConfigService(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<ApplicationConfiguration>> GetAppConfigAsync()
    {
        var response = new ServiceResponse<ApplicationConfiguration>
        {
            Message = "Application Configuration",
            Success = true,
            Data = await _context.ApplicationConfiguration.FirstOrDefaultAsync()
        };
        return response;
    }
}
