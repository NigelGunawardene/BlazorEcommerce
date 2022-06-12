
namespace BlazorEcommerce.Client.Pages;

public partial class Index
{
    [Inject]
    private IAppConfigService appConfigService { get; set; }

    [Inject]
    private IState<AppConfigState> AppConfigState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    //private async void TestMethod()
    //{
    //    var action = new SetAppConfigAction(await appConfigService.GetApplicationConfiguration());
    //    Dispatcher.Dispatch(action);
    //}

    protected override async Task OnInitializedAsync()
    {
        var action = new SetAppConfigAction(await appConfigService.GetApplicationConfiguration());
        Dispatcher.Dispatch(action);
    }
}
