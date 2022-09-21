using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services;
using GloboTicket.TicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using GloboTicket.TicketManagement.Application.Responses;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.BlazorWasm.Features.Categories
{
    public partial class AddCategoryPage
    {
        [Inject]
        public ICategoryDataService CategoryDataService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public CategoryVm CategoryViewModel { get; set; }
        public string Message { get; set; }

        protected override void OnInitialized()
        {
            CategoryViewModel = new CategoryVm();
        }

        protected async Task HandleValidSubmit()
        {
            var response = await CategoryDataService.CreateCategory(CategoryViewModel);
            HandleResponse(response);
        }

        private void HandleResponse(ApiResponse<CreateCategoryDto> response)
        {
            if (response.Success)
            {
                Message = "Category added";
            }
            else
            {
                Message = response.Message;
                if (!string.IsNullOrEmpty(response.ValidationErrors))
                    Message += response.ValidationErrors;
            }
        }
    }
}
