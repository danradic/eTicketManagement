using AutoMapper;
using Blazored.LocalStorage;
using eTicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using eTicketManagement.Application.Contracts.Infrastructure.Services;
using eTicketManagement.Application.Features.Orders.GetOrdersForMonth;

namespace eTicketManagement.Infrastructure.Services
{
    public class OrderDataService : BaseDataService, IOrderDataService
    {
        private readonly IMapper _mapper;

        public OrderDataService(
            ITicketManagementApiClient client,
            IMapper mapper,
            ILocalStorageService localStorage)
            : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<PagedOrdersForMonthVm> GetPagedOrderForMonth(
            DateTime date,
            int page,
            int size)
        {
            var orders = await _client.GetPagedOrdersForMonthAsync(date, page, size);
            //var mappedOrders = _mapper.Map<PagedOrderForMonthViewModel>(orders);
            return orders;
        }
    }
}
