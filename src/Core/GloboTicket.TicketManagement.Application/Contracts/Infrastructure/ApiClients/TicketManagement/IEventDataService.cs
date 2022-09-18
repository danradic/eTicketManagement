using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.BlazorWasm.Contracts
{
    public interface IEventDataService
    {
        Task<List<EventListVm>> GetAllEvents();
        Task<EventDetailVm> GetEventById(Guid id);
        Task<ApiResponse<Guid>> CreateEvent(EventDetailVm eventDetailViewModel);
        Task<ApiResponse<Guid>> UpdateEvent(EventDetailVm eventDetailViewModel);
        Task<ApiResponse<Guid>> DeleteEvent(Guid id);
    }
}
