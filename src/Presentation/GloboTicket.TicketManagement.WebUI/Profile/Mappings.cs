using AutoMapper;
using GloboTicket.TicketManagement.WebUI;

namespace GloboTicket.TicketManagement.App.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<EventDetailVm, CreateEventCommand>().ReverseMap();
            CreateMap<EventDetailVm, UpdateEventCommand>().ReverseMap();

        }
    }
}
