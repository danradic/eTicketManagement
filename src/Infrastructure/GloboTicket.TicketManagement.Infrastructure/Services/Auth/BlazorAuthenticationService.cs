using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using GloboTicket.TicketManagement.Application.Exceptions;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using SendGrid;
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
            AuthenticationResponse authenticationResponse = new();

            try
            {
                authenticationResponse = await _client.AuthenticateAsync(authenticationRequest);

                if (!string.IsNullOrEmpty(authenticationResponse.ErrorMessage)) 
                    return authenticationResponse;

                await _localStorage.SetItemAsync("token", authenticationResponse.Token);
                ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(authenticationRequest.Email);
                _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Token);

                return authenticationResponse;
            }
            catch (ApiException ex)
            {
                var apiResponse = ConvertApiExceptions<Guid>(ex);
                authenticationResponse.ErrorMessage = apiResponse.Message;

                if (!string.IsNullOrEmpty(apiResponse.ValidationErrors))
                {
                    authenticationResponse.ErrorMessage += apiResponse.ValidationErrors;
                }
                return authenticationResponse;
            }
        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest registrationRequest)
        {
            try
            {
                return await _client.RegisterAsync(registrationRequest);
            }
            catch (ApiException ex)
            {
                var apiResponse = ConvertApiExceptions<Guid>(ex);
                RegistrationResponse registrationResponse = new();
                registrationResponse.ErrorMessage = apiResponse.Message;

                if (!string.IsNullOrEmpty(apiResponse.ValidationErrors))
                {
                    registrationResponse.ErrorMessage += apiResponse.ValidationErrors;
                }
                return registrationResponse;
            }
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
