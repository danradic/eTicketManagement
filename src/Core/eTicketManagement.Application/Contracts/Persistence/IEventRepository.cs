using eTicketManagement.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace eTicketManagement.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
    }
}
