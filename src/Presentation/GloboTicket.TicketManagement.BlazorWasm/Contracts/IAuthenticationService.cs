using GloboTicket.TicketManagement.BlazorWasm.Services.Base;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.BlazorWasm.Contracts
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<AuthenticationResponse>> Authenticate(string email, string password);
        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
    }
}
