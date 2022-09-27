using Blazored.LocalStorage;
using eTicketManagement.Application.Contracts.Identity;
using eTicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using eTicketManagement.Application.Contracts.Infrastructure.Services;
using eTicketManagement.Infrastructure.ApiClients.TicketManagement;
using eTicketManagement.Infrastructure.Services;
using eTicketManagement.Infrastructure.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace eTicketManagement.Infrastructure
{
    public static class InfrastructureServiceRegistrationForBlazorWasm
    {
        public static IServiceCollection AddInfrastructureServicesForBlazorWasm(
            this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddBlazoredLocalStorage();
            services.AddAuthorizationCore();

            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7133") });
            services.AddHttpClient<ITicketManagementApiClient, TicketManagementApiClient>(client => client.BaseAddress = new Uri("https://localhost:7133"));

            services.AddScoped<IEventDataService, EventDataService>();
            services.AddScoped<ICategoryDataService, CategoryDataService>();
            services.AddScoped<IOrderDataService, OrderDataService>();
            services.AddScoped<IAuthenticationService, BlazorAuthenticationService>();

            return services;
        }
    }
}
