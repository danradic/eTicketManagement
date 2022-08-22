using MediatR;
using System;

namespace GloboTicket.TicketManagement.Application.Features.Events.GetEventDetail
{
    public class GetEventDetailQuery: IRequest<EventDetailVm>
    {
        public Guid Id { get; set; }
    }
}
