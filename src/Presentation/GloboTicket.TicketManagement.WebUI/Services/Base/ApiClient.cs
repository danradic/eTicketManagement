using System.Net.Http;

namespace GloboTicket.TicketManagement.WebUI.Services.Base
{
    public partial class ApiClient : IApiClient
    {
        public HttpClient HttpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
