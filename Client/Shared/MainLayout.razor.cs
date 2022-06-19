namespace BlazorEcommerce.Client.Shared;

public partial class MainLayout
{
    bool _drawerOpen { get; set; } = true;

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    [Inject]
    private IAppConfigService appConfigService { get; set; }

    //[Inject]
    //private IState<AppConfigState> AppConfigState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var appConfigAction = new SetAppConfigAction(await appConfigService.GetApplicationConfiguration());
        Dispatcher.Dispatch(appConfigAction);
    }

    // these 3 methods handle the reloading of the page on state change
    // Hook the state changed on page render, and unhook it at the end of component lifecycle
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //    if (firstRender)
    //    {
    //        AppConfigState.StateChanged += StateChanged;
    //    }
    //}

    //public void StateChanged(object sender, EventArgs args)
    //{
    //    InvokeAsync(StateHasChanged);
    //}

    //void IDisposable.Dispose()
    //{
    //    AppConfigState.StateChanged -= StateChanged;
    //}
}
