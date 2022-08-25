using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class EventListVm
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; } = String.Empty;
    }
}
