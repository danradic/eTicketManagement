using eTicketManagement.Application.Features.Events.Queries.GetEventDetail;
using eTicketManagement.Application.Features.Events.Queries.GetEventsList;
using eTicketManagement.Application.Responses;

namespace eTicketManagement.Application.Contracts.Infrastructure.Services
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
