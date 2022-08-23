using AutoMapper;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventDetail;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsList;
using GloboTicket.TicketManagement.Domain.Entities;

namespace GloboTicket.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
