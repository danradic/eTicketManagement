using eTicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using eTicketManagement.Application.Responses;

namespace eTicketManagement.Application.Contracts.Infrastructure.Services
{
    public interface ICategoryDataService
    {
        Task<List<CategoryListVm>> GetAllCategories();
        Task<List<CategoryEventListVm>> GetAllCategoriesWithEvents(bool includeHistory);
        Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryVm categoryViewModel);
    }
}
