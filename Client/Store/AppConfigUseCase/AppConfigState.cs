namespace BlazorEcommerce.Client.Store.AppConfigUseCase;

[FeatureState]
public class AppConfigState
{
    public ApplicationConfiguration CurrentAppConfigState { get; }

    private AppConfigState() { } // Required for creating initial state

    public AppConfigState(ApplicationConfiguration appConfigState)
    {
        this.CurrentAppConfigState = appConfigState;
    }
}