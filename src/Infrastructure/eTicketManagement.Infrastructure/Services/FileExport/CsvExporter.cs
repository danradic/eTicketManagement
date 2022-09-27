using CsvHelper;
using CsvHelper.Configuration;
using eTicketManagement.Application.Contracts.Infrastructure.Services.FileExport;
using System.Globalization;

namespace eTicketManagement.Infrastructure.Services.FileExport
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
