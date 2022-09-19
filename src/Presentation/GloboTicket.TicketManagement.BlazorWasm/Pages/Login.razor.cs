using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.BlazorWasm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.BlazorWasm.Pages
{
    public partial class Login
    {
        public LoginViewModel LoginViewModel { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Login()
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
            //if (!string.IsNullOrEmpty(response.ValidationErrors))
            //    Message += response.ValidationErrors;
            StateHasChanged();

        }
    }
}
