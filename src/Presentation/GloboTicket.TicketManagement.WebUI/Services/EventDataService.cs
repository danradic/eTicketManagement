﻿using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.App.Services.Base;
using GloboTicket.TicketManagement.WebUI.Contracts;
using GloboTicket.TicketManagement.WebUI.Services.Base;

namespace GloboTicket.TicketManagement.WebUI.Services
{
    public class EventDataService: BaseDataService, IEventDataService
    {
        
        private readonly IMapper _mapper;

        public EventDataService(ApiClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<EventListVm>> GetAllEvents()
        {
            var allEvents = await _client.GetAllEventsAsync();
            var mappedEvents = _mapper.Map<ICollection<EventListVm>>(allEvents);
            return mappedEvents.ToList();
        }

        public async Task<EventDetailVm> GetEventById(Guid id)
        {
            var selectedEvent = await _client.GetEventByIdAsync(id);
            var mappedEvent = _mapper.Map<EventDetailVm>(selectedEvent);
            return mappedEvent;
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
