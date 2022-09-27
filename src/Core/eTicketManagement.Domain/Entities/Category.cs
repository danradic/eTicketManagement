using eTicketManagement.Domain.Common;
using System;
using System.Collections.Generic;

namespace eTicketManagement.Domain.Entities
{
    public class Category: AuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Event> Events { get; set; }
    }
}
