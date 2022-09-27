using AutoMapper;
using eTicketManagement.Application.Contracts.Persistence;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using eTicketManagement.Application.Profiles;
using eTicketManagement.Application.UnitTests.Mocks;
using eTicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace eTicketManagement.Application.UnitTests.Categories.Queries
{
    public class GetCategoriesListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public GetCategoriesListQueryHandlerTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository(); ;
        }


        [Fact]
        public async Task GetCategoriesListTest() 
        {
            var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

            var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryListVm>>();

            result.Count.Equals(4);
        }
    }
}
