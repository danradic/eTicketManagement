using System;

namespace eTicketManagement.Application.Features.Categories.Commands.CreateCateogry
{
    public class CreateCategoryDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
