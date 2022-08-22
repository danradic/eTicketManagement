using MediatR;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Features.Events.GetEventsList
{
    public class GetEventsListQuery: IRequest<List<EventListVm>>
    {

    }
}
