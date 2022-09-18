using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Infrastructure.Services
{
    public class EventDataService : BaseDataService, IEventDataService
    {

        private readonly IMapper _mapper;

        public EventDataService(ITicketManagementApiClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<EventListVm>> GetAllEvents()
        {
            var allEvents = await _client.GetAllEventsAsync();
            //var mappedEvents = _mapper.Map<ICollection<EventListViewModel>>(allEvents);
            return allEvents.ToList();
        }

        public async Task<EventDetailVm> GetEventById(Guid id)
        {
            var selectedEvent = await _client.GetEventByIdAsync(id);
            //var mappedEvent = _mapper.Map<EventDetailViewModel>(selectedEvent);
            return selectedEvent;
        }

        public async Task<ApiResponse<Guid>> CreateEvent(EventDetailVm eventDetailViewModel)
        {
            try
            {
                CreateEventCommand createEventCommand = _mapper.Map<CreateEventCommand>(eventDetailViewModel);
                var newId = await _client.AddEventAsync(createEventCommand);
                return new ApiResponse<Guid>() { Data = newId, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> UpdateEvent(EventDetailVm eventDetailViewModel)
        {
            try
            {
                UpdateEventCommand updateEventCommand = _mapper.Map<UpdateEventCommand>(eventDetailViewModel);
                await _client.UpdateEventAsync(updateEventCommand);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }

        public async Task<ApiResponse<Guid>> DeleteEvent(Guid id)
        {
            try
            {
                await _client.DeleteEventAsync(id);
                return new ApiResponse<Guid>() { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<Guid>(ex);
            }
        }
    }
}
