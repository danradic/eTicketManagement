using GloboTicket.TicketManagement.WebUI.ViewModels;
using System;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.WebUI.Contracts
{
    public interface IOrderDataService
    {
        Task<PagedOrderForMonthViewModel> GetPagedOrderForMonth(DateTime date, int page, int size);
    }
}
