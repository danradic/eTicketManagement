using Blazored.LocalStorage;
using GloboTicket.TicketManagement.BlazorWasm.Auth;
using GloboTicket.TicketManagement.BlazorWasm.Contracts;
using GloboTicket.TicketManagement.BlazorWasm.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace GloboTicket.TicketManagement.BlazorWasm.Services
{
    public class AuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(
            IClient client, 
            ILocalStorageService localStorage, 
            AuthenticationStateProvider authenticationStateProvider
            ) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<ApiResponse<AuthenticationResponse>> Authenticate(string email, string password)
        {
            ApiResponse<AuthenticationResponse> apiResponse = new();

            try
            {
                AuthenticationRequest authenticationRequest = new() { Email = email, Password = password };
                var authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

                if (!string.IsNullOrEmpty(authenticationResponse.ErrorMessage))
                {
                    apiResponse.ValidationErrors = authenticationResponse.ErrorMessage;
                    apiResponse.Success = false;
                    return apiResponse;
                }

                await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);

                apiResponse.Success = true;
                apiResponse.Data = new AuthenticationResponse { Email = email };

                return apiResponse;
            }
            catch 
            {
                return apiResponse;
            }
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            RegistrationRequest registrationRequest = new() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
