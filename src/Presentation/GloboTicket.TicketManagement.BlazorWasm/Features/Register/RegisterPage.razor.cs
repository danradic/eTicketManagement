using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Features.Register;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using Microsoft.AspNetCore.Components;
using SendGrid;

namespace GloboTicket.TicketManagement.BlazorWasm.Features.Register
{
    public partial class RegisterPage
    {

        public RegisterVm RegisterViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Message { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public RegisterPage()
        {

        }
        protected override void OnInitialized()
        {
            RegisterViewModel = new RegisterVm();
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

            var registrationResponse = await AuthenticationService.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(registrationResponse.UserId))
            {
                NavigationManager.NavigateTo("home");
                return;
            }

            Message = registrationResponse.ErrorMessage;
            StateHasChanged();
        }
    }
}
