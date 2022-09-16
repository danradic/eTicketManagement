using System;

namespace GloboTicket.TicketManagement.BlazorWasm.ViewModels
{
    public class OrdersForMonthListViewModel
    {
        public Guid Id { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
