using eTicketManagement.Application.Contracts.Infrastructure.Services.Mail;
using eTicketManagement.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace eTicketManagement.Infrastructure.Services.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(
            IOptions<EmailSettings> mailSettings, 
            ILogger<EmailService> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmail(Email email)
        {
            var client = new SendGridClient(_emailSettings.ApiKey);

            var subject = email.Subject;
            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = _emailSettings.FromAddress,
                Name = _emailSettings.FromName
            };

            var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            var response = await client.SendEmailAsync(sendGridMessage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted ||
                response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _logger.LogInformation("Email sent.");
                return true;
            }

            _logger.LogError("Email sending failed.");
            return false;
        }
    }
}
