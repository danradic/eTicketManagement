using eTicketManagement.Application.Features.Orders.GetOrdersForMonth;

namespace eTicketManagement.Application.Contracts.Infrastructure.Services
{
    public interface IOrderDataService
    {
        Task<PagedOrdersForMonthVm> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
