using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;

namespace GloboTicket.TicketManagement.BlazorWasm.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<EventDetailVm, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailVm, UpdateEventCommand>().ReverseMap();
            CreateMap<CategoryVm, CreateCategoryCommand>().ReverseMap();
        }
    }
}
