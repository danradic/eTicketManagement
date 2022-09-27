using eTicketManagement.Application.Responses;

namespace eTicketManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {

        }

        public CreateCategoryDto? Category { get; set; }
    }
}