using System.Net.Http;

namespace GloboTicket.TicketManagement.BlazorWasm.Services.Base
{
    public partial interface IClient
    {
        public HttpClient HttpClient { get; }

    }
}
