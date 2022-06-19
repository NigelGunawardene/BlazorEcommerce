namespace BlazorEcommerce.Client.Shared;

public partial class MainLayout
{
    bool _drawerOpen { get; set; } = true;

    void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }
}
