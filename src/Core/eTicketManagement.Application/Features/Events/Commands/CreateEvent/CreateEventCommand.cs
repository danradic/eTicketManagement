using MediatR;
using System;

namespace eTicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand: IRequest<Guid>
    {
        public string Name { get; set; } = String.Empty;
        public int Price { get; set; }
        public string Artist { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = String.Empty;
        public string ImageUrl { get; set; } = String.Empty;
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By: {Artist}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
