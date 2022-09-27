using eTicketManagement.Application.Features.Categories.Commands.CreateCateogry;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using eTicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using eTicketManagement.Application.Features.Events.Commands.CreateEvent;
using eTicketManagement.Application.Features.Events.Commands.UpdateEvent;
using eTicketManagement.Application.Features.Events.Queries.GetEventDetail;
using eTicketManagement.Application.Features.Events.Queries.GetEventsList;
using eTicketManagement.Application.Features.Orders.GetOrdersForMonth;
using eTicketManagement.Application.Models.Authentication;
using eTicketManagement.Application.Exceptions;

namespace eTicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement
{
    public partial interface ITicketManagementApiClient
    {
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest body, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest body, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<CategoryListVm>> GetAllCategoriesAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<CategoryListVm>> GetAllCategoriesAsync(CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<CategoryEventListVm>> GetCategoriesWithEventsAsync(bool? includeHistory);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<CategoryEventListVm>> GetCategoriesWithEventsAsync(bool? includeHistory, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<CreateCategoryCommandResponse> AddCategoryAsync(CreateCategoryCommand body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<CreateCategoryCommandResponse> AddCategoryAsync(CreateCategoryCommand body, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<EventListVm>> GetAllEventsAsync();

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<ICollection<EventListVm>> GetAllEventsAsync(CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<Guid> AddEventAsync(CreateEventCommand body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<Guid> AddEventAsync(CreateEventCommand body, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task UpdateEventAsync(UpdateEventCommand body);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task UpdateEventAsync(UpdateEventCommand body, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<EventDetailVm> GetEventByIdAsync(Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<EventDetailVm> GetEventByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task DeleteEventAsync(Guid id);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task DeleteEventAsync(Guid id, CancellationToken cancellationToken);

        /// <exception cref="ApiException">A server side error occurred.</exception>
        //System.Threading.Tasks.Task<FileResponse> ExportEventsAsync();

        ///// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        ///// <exception cref="ApiException">A server side error occurred.</exception>
        //System.Threading.Tasks.Task<FileResponse> ExportEventsAsync(System.Threading.CancellationToken cancellationToken);

        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<PagedOrdersForMonthVm> GetPagedOrdersForMonthAsync(DateTime? date, int? page, int? size);

        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Success</returns>
        /// <exception cref="ApiException">A server side error occurred.</exception>
        Task<PagedOrdersForMonthVm> GetPagedOrdersForMonthAsync(DateTime? date, int? page, int? size, CancellationToken cancellationToken);

        public HttpClient HttpClient { get; }
    }
}
