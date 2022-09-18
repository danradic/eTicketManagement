using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services.FileExport;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services.Mail;
using GloboTicket.TicketManagement.Application.Models.Mail;
using GloboTicket.TicketManagement.Infrastructure.Services.FileExport;
using GloboTicket.TicketManagement.Infrastructure.Services.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTicket.TicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }
    }
}
