using GloboTicket.TicketManagement.BlazorWasm.ViewModels;
using System;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.BlazorWasm.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
