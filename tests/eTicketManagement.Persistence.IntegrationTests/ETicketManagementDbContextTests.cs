using eTicketManagement.Application.Contracts;
using eTicketManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;

namespace eTicketManagement.Persistence.IntegrationTests
{
    public class ETicketManagementDbContextTests
    {
        private readonly ETicketManagementDbContext _eTicketManagementDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;

        public ETicketManagementDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ETicketManagementDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(m => m.UserId).Returns(_loggedInUserId);

            _eTicketManagementDbContext = new ETicketManagementDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var ev = new Event() {
                EventId = Guid.NewGuid(),
                Name = "Test event", 
                Artist = "Test artist", 
                Description = "Test description",
                ImageUrl = "Test url",
                LastModifiedBy = "test admin"
            };

            _eTicketManagementDbContext.Events.Add(ev);
            await _eTicketManagementDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }
    }
}
