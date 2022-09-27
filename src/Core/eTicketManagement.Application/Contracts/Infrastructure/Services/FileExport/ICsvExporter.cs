using eTicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;

namespace eTicketManagement.Application.Contracts.Infrastructure.Services.FileExport
{
    public interface ICsvExporter
    {
        byte[] ExportDataToCsv<T>(List<T> exportDtos);
    }
}
