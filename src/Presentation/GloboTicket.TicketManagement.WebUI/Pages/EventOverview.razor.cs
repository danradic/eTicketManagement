using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.WebUI.Pages
{
    public partial class EventOverview
    {

        [Inject]
        public ApiClient _apiClient { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public ICollection<EventListVm> Events { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Events = await _apiClient.GetAllEventsAsync();
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
