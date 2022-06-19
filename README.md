# BlazorEcommerce

# TODO

1. Make excel files for products and users. make one time import script to parse excel. this will be resuable for seeding
2. Ability to do rebranding should be the focus

This is how to do state management example -

public partial class Index : IDisposable
{
[Inject]
private IAppConfigService appConfigService { get; set; }

    [Inject]
    private IState<AppConfigState> AppConfigState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var action = new SetAppConfigAction(await appConfigService.GetApplicationConfiguration());
        Dispatcher.Dispatch(action);
    }

    // these 3 methods handle the reloading of the page on state change
    // Hook the state changed on page render, and unhook it at the end of component lifecycle
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            AppConfigState.StateChanged += StateChanged;
        }
    }

    public void StateChanged(object sender, EventArgs args)
    {
        InvokeAsync(StateHasChanged);
    }

    void IDisposable.Dispose()
    {
        AppConfigState.StateChanged -= StateChanged;
    }

}

How to create new page -

right click folder, add razor component, type ONLY THE NAME OF THE COMPONENT i.e - ProductList (not ProductList.razor or anything)
To add code/css behind, - right click folder, add new item, select c#/css component and then type matching name
