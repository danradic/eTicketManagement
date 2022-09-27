using MediatR;

namespace eTicketManagement.Application.Features.Events.Queries.GetEventsExport
{
    public class GetEventsExportQuery: IRequest<EventExportFileVm>
    {
    }
}
