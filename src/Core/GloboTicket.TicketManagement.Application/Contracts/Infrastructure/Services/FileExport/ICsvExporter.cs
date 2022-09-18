using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services.FileExport
{
    public interface ICsvExporter
    {
        byte[] ExportDataToCsv<T>(List<T> exportDtos);
    }
}
