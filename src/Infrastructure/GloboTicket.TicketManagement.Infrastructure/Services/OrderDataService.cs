using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services;
using GloboTicket.TicketManagement.Application.Features.Orders.GetOrdersForMonth;

namespace GloboTicket.TicketManagement.Infrastructure.Services
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
