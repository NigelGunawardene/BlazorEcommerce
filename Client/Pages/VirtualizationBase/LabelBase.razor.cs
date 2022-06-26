using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce.Client.Pages.VirtualizationBase
{
    public partial class LabelBase
    {
        [Parameter]
        public string Value { get; set; }

        public void SetValue(string value)
        {
            this.Value = value;
            InvokeAsync(workItem: StateHasChanged);
        }
    }
}