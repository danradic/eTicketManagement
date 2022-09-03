using System.Net.Http;

namespace GloboTicket.TicketManagement.WebUI.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
