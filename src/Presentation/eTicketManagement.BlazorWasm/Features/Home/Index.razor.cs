using eTicketManagement.Application.Contracts.Identity;
using eTicketManagement.Infrastructure.Services.Auth;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace eTicketManagement.BlazorWasm.Features.Home
{
    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await ((CustomAuthenticationStateProvider)AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void NavigateToLogin()
        {
            NavigationManager.NavigateTo("login");
        }

        protected void NavigateToRegister()
        {
            NavigationManager.NavigateTo("register");
        }

        protected async void Logout()
        {
            await AuthenticationService.Logout();
        }
    }
}
