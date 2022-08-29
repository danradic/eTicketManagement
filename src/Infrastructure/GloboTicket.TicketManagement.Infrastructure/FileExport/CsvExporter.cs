using CsvHelper;
using CsvHelper.Configuration;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using GloboTicket.TicketManagement.Application.Features.Events.Queries.GetEventsExport;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace GloboTicket.TicketManagement.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportDataToCsv<T>(List<T> exportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture);

                using var csvWriter = new CsvWriter(streamWriter, config);
                csvWriter.WriteRecords(exportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
