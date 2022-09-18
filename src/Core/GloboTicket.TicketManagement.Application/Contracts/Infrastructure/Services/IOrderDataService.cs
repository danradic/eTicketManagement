using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services
{
    public interface IOrderDataService
    {
        Task<PagedOrdersForMonthVm> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
