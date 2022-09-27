using System;

namespace eTicketManagement.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"{name} ({key}) is not found")
        { }
    }
}
