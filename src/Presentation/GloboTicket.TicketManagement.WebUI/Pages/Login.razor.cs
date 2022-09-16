using GloboTicket.TicketManagement.WebUI.Contracts;
using GloboTicket.TicketManagement.WebUI.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.WebUI.Pages
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
            var response = await AuthenticationService.Authenticate(LoginViewModel.Email, LoginViewModel.Password);

            if (response.Success == true)
            {
                NavigationManager.NavigateTo("/");
                return;
            }

            Message = response.Message;
            if (!string.IsNullOrEmpty(response.ValidationErrors))
                Message += response.ValidationErrors;
            StateHasChanged();

        }
    }
}
