using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;

namespace GloboTicket.TicketManagement.BlazorWasm.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrdersForMonthVm> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
