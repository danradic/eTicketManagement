using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.Application.Contracts.Identity;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.ApiClients.TicketManagement;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure.Services;
using GloboTicket.TicketManagement.BlazorWasm;
using GloboTicket.TicketManagement.Infrastructure.ApiClients.TicketManagement;
using GloboTicket.TicketManagement.Infrastructure.Services;
using GloboTicket.TicketManagement.Infrastructure.Services.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7133") });

builder.Services.AddHttpClient<ITicketManagementApiClient, TicketManagementApiClient>(client => client.BaseAddress = new Uri("https://localhost:7133"));

builder.Services.AddScoped<IEventDataService, EventDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();
builder.Services.AddScoped<IAuthenticationService, BlazorAuthenticationService>();

await builder.Build().RunAsync();
