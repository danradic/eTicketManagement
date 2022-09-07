using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.WebUI;
using GloboTicket.TicketManagement.WebUI.Auth;
using GloboTicket.TicketManagement.WebUI.Contracts;
using GloboTicket.TicketManagement.WebUI.Services;
using GloboTicket.TicketManagement.WebUI.Services.Base;
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

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]) });

builder.Services.AddHttpClient<IApiClient, ApiClient>(client => client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]));

builder.Services.AddScoped<IEventDataService, EventDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<IOrderDataService, OrderDataService>();

await builder.Build().RunAsync();
