﻿using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Features.Login;
using GloboTicket.TicketManagement.Application.Models.Authentication;
using Microsoft.AspNetCore.Components;

namespace GloboTicket.TicketManagement.BlazorWasm.Features.Login
{
    public partial class LoginPage
    {
        public LoginVm LoginViewModel { get; set; }

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
            LoginViewModel = new LoginVm();
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
