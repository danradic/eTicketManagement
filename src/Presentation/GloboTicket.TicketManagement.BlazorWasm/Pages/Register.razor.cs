using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using GloboTicket.TicketManagement.BlazorWasm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.BlazorWasm.Pages
{
    public partial class Register
    {

        public RegisterViewModel RegisterViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public Register()
        {

        }
        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterViewModel();
        }

        protected async void HandleValidSubmit()
        {
            var registrationRequest = new RegistrationRequest()
            {
                FirstName = RegisterViewModel.FirstName,
                LastName = RegisterViewModel.LastName,
                UserName = RegisterViewModel.UserName,
                Email = RegisterViewModel.Email,
                Password = RegisterViewModel.Password
            };

            var result = await AuthenticationService.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(result.UserId))
            {
                NavigationManager.NavigateTo("home");
                return;
            }
            Message = "Something went wrong, please try again.";
        }
    }
}
