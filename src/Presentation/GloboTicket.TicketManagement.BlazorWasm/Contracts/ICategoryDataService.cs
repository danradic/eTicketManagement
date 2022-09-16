using GloboTicket.TicketManagement.BlazorWasm.Services.Base;
using GloboTicket.TicketManagement.BlazorWasm.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.BlazorWasm.Contracts
{
    public interface ICategoryDataService
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<List<CategoryEventsViewModel>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CategoryDto>> CreateCategory(CategoryViewModel categoryViewModel);
    }
}
