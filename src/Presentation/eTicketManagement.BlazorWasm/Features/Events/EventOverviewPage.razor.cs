using eTicketManagement.Application.Contracts.Infrastructure.Services;
using eTicketManagement.Application.Features.Events.Queries.GetEventsList;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace eTicketManagement.BlazorWasm.Features.Events
{
    public partial class EventOverviewPage
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<EventListVm> Events { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Events = await EventDataService.GetAllEvents();
        }

        protected void AddNewEvent()
        {
            NavigationManager.NavigateTo("/eventdetails");
        }

        [Inject]
        public HttpClient HttpClient { get; set; }

        protected async Task ExportEvents()
        {
            if (await JSRuntime.InvokeAsync<bool>("confirm", $"Do you want to export this list to Excel?"))
            {
                var response = await HttpClient.GetAsync($"https://localhost:7133/api/events/export");
                response.EnsureSuccessStatusCode();
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var fileName = $"MyReport{DateTime.Now.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture)}.csv";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            }
        }
    }
}
