using eTicketManagement.Application.Models.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicketManagement.Application.Contracts.Infrastructure.Services.Mail
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
