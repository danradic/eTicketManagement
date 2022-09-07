using System;

namespace GloboTicket.TicketManagement.WebUI.ViewModels
{
    public class EventListViewModel
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
        public string ImageUrl { get; set; }
    }
}
