using CsvHelper;
using CsvHelper.Configuration;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using System.Globalization;

namespace GloboTicket.TicketManagement.Infrastructure.FileExport
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
