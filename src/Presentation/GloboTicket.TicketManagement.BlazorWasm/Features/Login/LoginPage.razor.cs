using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.BlazorWasm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.BlazorWasm.Features.Login
{
    public partial class LoginPage
    {
        public LoginViewModel LoginViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public LoginPage()
        {

        }

        protected override void OnInitialized()
        {
            LoginViewModel = new LoginViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var authenticationRequest = new AuthenticationRequest() { Email = LoginViewModel.Email, Password = LoginViewModel.Password };
            var response = await AuthenticationService.AuthenticateAsync(authenticationRequest);

            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            Message = response.ErrorMessage;
            StateHasChanged();
        }
    }
}
