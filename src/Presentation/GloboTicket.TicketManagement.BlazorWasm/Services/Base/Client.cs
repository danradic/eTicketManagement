using System.Net.Http;

namespace GloboTicket.TicketManagement.BlazorWasm.Services.Base
{
    public partial class Client : IClient
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
