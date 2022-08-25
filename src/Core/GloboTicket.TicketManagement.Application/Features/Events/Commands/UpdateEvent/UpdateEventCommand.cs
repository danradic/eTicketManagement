using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand: IRequest
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Price { get; set; }
        public string Artist { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public Guid CategoryId { get; set; }
    }
}
