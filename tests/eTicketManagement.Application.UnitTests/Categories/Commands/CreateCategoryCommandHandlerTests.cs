using AutoMapper;
using eTicketManagement.Application.Contracts.Persistence;
using eTicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using eTicketManagement.Application.Profiles;
using eTicketManagement.Application.UnitTests.Mocks;
using eTicketManagement.Domain.Entities;
using Moq;
using Shouldly;

namespace eTicketManagement.Application.UnitTests.Categories.Commands
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

        public CreateCategoryCommandHandlerTests()
        {
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();

            _mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        }

        [Fact]
        public async Task CreateCategoryTest() 
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockCategoryRepository.Object);

            await handler.Handle(new CreateCategoryCommand() { Name = "Test" }, CancellationToken.None);

            var allCategories = await _mockCategoryRepository.Object.ListAllAsync();

            allCategories.Count.Equals(5);
        }
    }
}
