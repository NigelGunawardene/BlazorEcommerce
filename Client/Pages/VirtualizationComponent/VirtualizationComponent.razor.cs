using BlazorEcommerce.Client.Brokers.DataSources;
using BlazorEcommerce.Client.Pages.VirtualizationBase;
using BlazorEcommerce.Client.Services;
using BlazorEcommerce.Shared.Enums;


namespace BlazorEcommerce.Client.Pages.VirtualizationComponent
{
    public partial class VirtualizationComponent<T> : ComponentBase
    {
        [Parameter]
        public RenderFragment<T> ChildContent { get; set; }

        [Parameter]
        public IQueryable<T> DataSource { get; set; }

        public VirtualizationComponentState State { get; set; }
        public string ErrorMessage { get; set; }
        public LabelBase Label { get; set; }
        private IDataSourceBroker<T> dataSourceBroker;
        private IVirtualizationService<T> virtualizationService;

        protected override void OnInitialized()
        {
            this.dataSourceBroker =
                new DataSourceBroker<T>(this.DataSource);

            this.virtualizationService =
                new VirtualizationService<T>(this.dataSourceBroker);

            this.State = VirtualizationComponentState.Content;
            base.OnInitialized();
        }

        private (IQueryable<T> DataSource, int TotalCount) RetrieveData(
            int index,
            int quantity)
        {
            try
            {

                IQueryable<T> data = this.virtualizationService
                    .LoadPage((uint)index, (uint)quantity);

                int totalCount = data.Count();

                return (data, totalCount);

            }
            catch (System.Exception exception)
            {
                this.State = VirtualizationComponentState.Error;
                this.ErrorMessage = exception.Message;
                InvokeAsync(StateHasChanged);
                return default;
            }
        }

        public bool IsStateContent =>
            this.State == VirtualizationComponentState.Content;

        public bool IsStateError =>
            this.State == VirtualizationComponentState.Error;
    }
}