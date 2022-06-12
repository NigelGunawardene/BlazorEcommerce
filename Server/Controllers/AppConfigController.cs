using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AppConfigController : ControllerBase
{
    private IAppConfigService _appConfigService;

    public AppConfigController(IAppConfigService appConfigService)
    {
        _appConfigService = appConfigService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<ApplicationConfiguration>>> GetApplicationConfiguration()
    {
        var response = await _appConfigService.GetAppConfigAsync();
        return Ok(response);
    }
}
