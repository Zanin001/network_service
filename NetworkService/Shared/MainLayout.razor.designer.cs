using Microsoft.AspNetCore.Components;
using Radzen;
using Radzen.Blazor;

namespace NetworkService.Shared;

public partial class MainLayout : LayoutComponentBase
{
    [Inject]
    protected NavigationManager NavigationManager { get; set; }

    [Inject]
    protected DialogService DialogService { get; set; }

    [Inject]
    protected TooltipService TooltipService { get; set; }

    [Inject]
    protected ContextMenuService ContextMenuService { get; set; }

    [Inject]
    protected NotificationService NotificationService { get; set; }

    protected RadzenBody MainBody;
    protected RadzenSidebar MainSidebar;

    protected async Task MainSidebarToggleClick(dynamic args)
    {
        await InvokeAsync(() => { MainBody.Toggle(); });

        await InvokeAsync(() => { MainSidebar.Toggle(); });
    }
}
