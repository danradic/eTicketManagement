using System;

namespace eTicketManagement.Application.Exceptions
{
    public class BadRequestException: ApplicationException
    {
        public BadRequestException(string message): base(message)
        {

        }
    }
}
