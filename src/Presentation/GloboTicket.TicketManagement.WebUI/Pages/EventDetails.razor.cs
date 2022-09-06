using AutoMapper;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.ObjectModel;

namespace GloboTicket.TicketManagement.WebUI.Pages
{
    public partial class EventDetails
    {

        [Inject]
        public IMapper _mapper { get; set; }
        
        [Inject]
        public ApiClient _apiClient { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public EventDetailVm EventDetailViewModel { get; set; } 
            = new EventDetailVm() { Date = DateTime.Now.AddDays(1) };

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
                EventDetailViewModel = await _apiClient.GetEventByIdAsync(SelectedEventId);
                SelectedCategoryId = EventDetailViewModel.CategoryId.ToString();
            }

            var list = await _apiClient.GetAllCategoriesAsync();
            Categories = new ObservableCollection<CategoryListVm>(list);
            SelectedCategoryId = Categories.FirstOrDefault().CategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            EventDetailViewModel.CategoryId = Guid.Parse(SelectedCategoryId);
            ApiResponse<Guid> response;

            if (SelectedEventId == Guid.Empty)
            {
                CreateEventCommand createEventCommand = _mapper.Map<CreateEventCommand>(EventDetailViewModel);
                var newId = await _apiClient.AddEventAsync(createEventCommand);
                response = new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            else
            {
                UpdateEventCommand updateEventCommand = _mapper.Map<UpdateEventCommand>(EventDetailViewModel);
                await _apiClient.UpdateEventAsync(updateEventCommand);
            }
            HandleResponse(response);

        }

        protected async Task DeleteEvent()
        {
            //var response = await EventDataService.DeleteEvent(SelectedEventId);
            //HandleResponse(response);
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
