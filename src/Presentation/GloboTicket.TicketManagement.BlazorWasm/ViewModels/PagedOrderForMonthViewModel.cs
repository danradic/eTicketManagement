using System.Collections.Generic;

namespace GloboTicket.TicketManagement.BlazorWasm.ViewModels
{
    public class PagedOrderForMonthViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthListViewModel> OrdersForMonth { get; set; }
    }
}
