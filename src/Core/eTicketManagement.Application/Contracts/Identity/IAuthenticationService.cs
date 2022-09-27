using eTicketManagement.Application.Models.Authentication;

namespace eTicketManagement.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
        Task Logout();
    }
}
