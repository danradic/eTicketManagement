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
            using MemoryStream memoryStream = new();
            using (StreamWriter streamWriter = new(memoryStream))
            {
                CsvConfiguration config = new(CultureInfo.InvariantCulture);

                using CsvWriter csvWriter = new(streamWriter, config);
                csvWriter.WriteRecords(exportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
