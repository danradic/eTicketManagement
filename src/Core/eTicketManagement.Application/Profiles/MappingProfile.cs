using AutoMapper;
using eTicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using eTicketManagement.Application.Features.Events.Commands.CreateEvent;
using eTicketManagement.Application.Features.Events.Commands.UpdateEvent;
using eTicketManagement.Application.Features.Events.Queries.GetEventDetail;
using eTicketManagement.Application.Features.Events.Queries.GetEventsExport;
using eTicketManagement.Application.Features.Events.Queries.GetEventsList;
using eTicketManagement.Application.Features.Orders.GetOrdersForMonth;
using eTicketManagement.Domain.Entities;

namespace eTicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, EventExportDto>().ReverseMap();

            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Id, input => input.MapFrom(i => i.CategoryId))
                .ReverseMap();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
