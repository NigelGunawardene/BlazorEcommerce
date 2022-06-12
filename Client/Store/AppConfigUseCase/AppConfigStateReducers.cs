namespace BlazorEcommerce.Client.Store.AppConfigUseCase;

public static class AppConfigStateReducers
{
    [ReducerMethod]
    public static AppConfigState ReduceUpdateAppConfigAction(AppConfigState state, SetAppConfigAction action) =>
        new AppConfigState(appConfigState: action.AppConfig);
}
