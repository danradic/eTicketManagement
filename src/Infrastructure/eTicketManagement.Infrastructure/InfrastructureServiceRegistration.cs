using eTicketManagement.Application.Contracts.Infrastructure.Services.FileExport;
using eTicketManagement.Application.Contracts.Infrastructure.Services.Mail;
using eTicketManagement.Application.Models.Mail;
using eTicketManagement.Infrastructure.Services.FileExport;
using eTicketManagement.Infrastructure.Services.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eTicketManagement.Infrastructure
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
