using GloboTicket.TicketManagement.WebUI.Services.Base;
using GloboTicket.TicketManagement.WebUI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.WebUI.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
