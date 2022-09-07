﻿using AutoMapper;
using GloboTicket.TicketManagement.WebUI.Services.Base;
using GloboTicket.TicketManagement.WebUI.ViewModels;

namespace GloboTicket.TicketManagement.WebUI.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            //Vms are coming in from the API, ViewModel are the local entities in Blazor
            CreateMap<EventListVm, EventListViewModel>().ReverseMap();
            CreateMap<EventDetailVm, EventDetailViewModel>().ReverseMap();

            CreateMap<EventDetailViewModel, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailViewModel, UpdateEventCommand>().ReverseMap();

            CreateMap<CategoryEventDto, EventNestedViewModel>().ReverseMap();

            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryEventListVm, CategoryEventsViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryDto>().ReverseMap();

            CreateMap<PagedOrdersForMonthVm, PagedOrderForMonthViewModel>().ReverseMap();
            CreateMap<OrdersForMonthDto, OrdersForMonthListViewModel>().ReverseMap();
        }
    }
}
