using System;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class CategoryEventListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<CategoryEventDto>? Events { get; set; }
    }
}
