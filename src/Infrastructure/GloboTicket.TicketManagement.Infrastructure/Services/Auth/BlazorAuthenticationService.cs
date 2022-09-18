using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.Application.Responses;
using System.Net.Http.Headers;

namespace GloboTicket.TicketManagement.Infrastructure.Services.Auth
{
    public class BlazorAuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public BlazorAuthenticationService(
            ITicketManagementApiClient client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider
            ) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest authenticationRequest)
        {
            var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

            if (!string.IsNullOrEmpty(authenticationResponse.ErrorMessage))
            {
                return authenticationResponse;
            }

            await _localStorage.SetItemAsync("token", authenticationResponse.Token);
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(authenticationRequest.Email);
            _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);

            return authenticationResponse;
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest registrationRequest)
        {
            return await _client.RegisterAsync(registrationRequest);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
