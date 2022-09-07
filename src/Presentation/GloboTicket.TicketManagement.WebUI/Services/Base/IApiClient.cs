namespace GloboTicket.TicketManagement.WebUI.Services.Base
{
    public partial interface IApiClient
    {
        public HttpClient HttpClient { get; }
    }
}
