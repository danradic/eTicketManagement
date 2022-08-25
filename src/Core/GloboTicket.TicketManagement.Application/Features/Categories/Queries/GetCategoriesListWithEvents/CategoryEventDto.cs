using System;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventDto
    {
        public Guid EventId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Price { get; set; }
        public string Artist { get; set; } = String.Empty;
        public DateTime Date { get; set; }
        public Guid CategoryId { get; set; }
    }
}
