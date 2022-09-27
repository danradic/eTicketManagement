using AutoMapper;
using eTicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using eTicketManagement.Application.Features.Events.Commands.CreateEvent;
using eTicketManagement.Application.Features.Events.Commands.UpdateEvent;
using eTicketManagement.Application.Features.Events.Queries.GetEventDetail;

namespace eTicketManagement.BlazorWasm.Profiles
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
