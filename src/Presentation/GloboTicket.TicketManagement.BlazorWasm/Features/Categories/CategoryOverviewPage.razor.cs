using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.BlazorWasm.Features.Categories
{
    public partial class CategoryOverviewPage
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<CategoryEventListVm> Categories { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
        }

        protected async void OnIncludeHistoryChanged(ChangeEventArgs args)
        {
            if ((bool)args.Value)
            {
                Categories = await CategoryDataService.GetAllCategoriesWithEvents(true);
            }
            else
            {
                Categories = await CategoryDataService.GetAllCategoriesWithEvents(false);
            }
        }
    }
}
