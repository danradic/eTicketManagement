using eTicketManagement.Application.Contracts.Infrastructure.Services;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using eTicketManagement.Application.Features.Events.Queries.GetEventDetail;
using eTicketManagement.Application.Responses;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace eTicketManagement.BlazorWasm.Features.Events
{
    public partial class EventDetailsPage
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EventDetailVm EventDetailVm { get; set; }
            = new() { Date = DateTime.Now.AddDays(1) };

        public ObservableCollection<CategoryListVm> Categories { get; set; }
            = new ObservableCollection<CategoryListVm>();

        public string Message { get; set; }
        public string SelectedCategoryId { get; set; }

        [Parameter]
        public string EventId { get; set; }
        private Guid SelectedEventId = Guid.Empty;

        protected override async Task OnInitializedAsync()
        {
            if (Guid.TryParse(EventId, out SelectedEventId))
            {
                EventDetailVm = await EventDataService.GetEventById(SelectedEventId);
                SelectedCategoryId = EventDetailVm.CategoryId.ToString();
            }

            var list = await CategoryDataService.GetAllCategories();
            Categories = new ObservableCollection<CategoryListVm>(list);

            if (string.IsNullOrEmpty(SelectedCategoryId))
            {
                SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
            }
        }

        protected async Task HandleValidSubmit()
        {
            EventDetailVm.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedEventId == Guid.Empty)
            {
                response = await EventDataService.CreateEvent(EventDetailVm);
            }
            else
            {
                response = await EventDataService.UpdateEvent(EventDetailVm);
            }
            HandleResponse(response);

        }

        protected async Task DeleteEvent()
        {
            var response = await EventDataService.DeleteEvent(SelectedEventId);
            HandleResponse(response);
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/eventoverview");
        }

        private void HandleResponse(ApiResponse<Guid> response)
        {
            if (response.Success)
            {
                NavigationManager.NavigateTo("/eventoverview");
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
