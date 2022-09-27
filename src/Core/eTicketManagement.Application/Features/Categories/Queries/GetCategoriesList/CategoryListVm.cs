using System;

namespace eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class CategoryListVm
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
