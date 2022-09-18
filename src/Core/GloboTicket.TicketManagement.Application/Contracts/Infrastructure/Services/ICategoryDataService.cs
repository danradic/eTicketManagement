using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using GloboTicket.TicketManagement.Application.Responses;

namespace GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services
{
    public interface ICategoryDataService
    {
        Task<List<CategoryListVm>> GetAllCategories();
        Task<List<CategoryEventListVm>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryVm categoryViewModel);
    }
}
