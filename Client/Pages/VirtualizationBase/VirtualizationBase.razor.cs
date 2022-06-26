﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BlazorEcommerce.Client.Pages.VirtualizationBase
{
    public partial class VirtualizationBase<T> : ComponentBase
    {
        [Parameter]
        public RenderFragment<T> ChildContent { get; set; }

        [Parameter]
        public int OverscanCount { get; set; } = 3;

        [Parameter]
        public CallBackSourceDelegate<T> CallBackSource { get; set; }

        private async ValueTask<ItemsProviderResult<T>> GetItemsAsync(
            ItemsProviderRequest request)
        {
            var data = CallBackSource.Invoke(request.StartIndex, request.Count);

            return new ItemsProviderResult<T>(data.DataSource, data.TotalCount);
        }
    }

    public delegate (IQueryable<T> DataSource, int TotalCount)
        CallBackSourceDelegate<T>(int startIndex, int count);
}
