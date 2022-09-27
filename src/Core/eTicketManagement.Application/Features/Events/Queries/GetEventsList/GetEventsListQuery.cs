using MediatR;
using System.Collections.Generic;

namespace eTicketManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<List<EventListVm>>
    {

    }
}
