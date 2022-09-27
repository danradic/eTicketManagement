using eTicketManagement.API.IntegrationTests.Base;
using eTicketManagement.Application.Features.Events.Queries.GetEventsList;
using Newtonsoft.Json;

namespace eTicketManagement.API.IntegrationTests.Controllers
{

    public class EventsControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public EventsControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("api/Events");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<EventListVm>>(responseString);
            
            Assert.IsType<List<EventListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
