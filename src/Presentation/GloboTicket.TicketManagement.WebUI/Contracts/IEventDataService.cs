using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.WebUI.Services;

namespace GloboTicket.TicketManagement.WebUI.Contracts
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
