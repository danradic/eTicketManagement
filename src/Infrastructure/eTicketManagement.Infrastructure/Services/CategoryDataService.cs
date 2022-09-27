using AutoMapper;
using Blazored.LocalStorage;
using eTicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using eTicketManagement.Application.Contracts.Infrastructure.Services;
using eTicketManagement.Application.Exceptions;
using eTicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using eTicketManagement.Application.Responses;

namespace eTicketManagement.Infrastructure.Services
{
    public class CategoryDataService : BaseDataService, ICategoryDataService
    {
        private readonly IMapper _mapper;

        public CategoryDataService(ITicketManagementApiClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<CategoryListVm>> GetAllCategories()
        {
            await AddBearerToken();

            var allCategories = await _client.GetAllCategoriesAsync();
            //var mappedCategories = _mapper.Map<ICollection<CategoryViewModel>>(allCategories);
            return allCategories.ToList();

        }

        public async Task<List<CategoryEventListVm>> GetAllCategoriesWithEvents(bool includeHistory)
        {
            await AddBearerToken();

            var allCategories = await _client.GetCategoriesWithEventsAsync(includeHistory);
            //var mappedCategories = _mapper.Map<ICollection<CategoryEventsViewModel>>(allCategories);
            return allCategories.ToList();

        }

        public async Task<ApiResponse<CreateCategoryDto>> CreateCategory(CategoryVm categoryViewModel)
        {
            try
            {
                ApiResponse<CreateCategoryDto> apiResponse = new ApiResponse<CreateCategoryDto>();
                CreateCategoryCommand createCategoryCommand = _mapper.Map<CreateCategoryCommand>(categoryViewModel);
                var createCategoryCommandResponse = await _client.AddCategoryAsync(createCategoryCommand);
                if (createCategoryCommandResponse.Success)
                {
                    apiResponse.Data = _mapper.Map<CreateCategoryDto>(createCategoryCommandResponse.Category);
                    apiResponse.Success = true;
                }
                else
                {
                    apiResponse.Data = null;
                    foreach (var error in createCategoryCommandResponse.ValidationErrors)
                    {
                        apiResponse.ValidationErrors += error + Environment.NewLine;
                    }
                }
                return apiResponse;
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<CreateCategoryDto>(ex);
            }
        }
    }
}