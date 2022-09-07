using AutoMapper;
using Blazored.LocalStorage;
using GloboTicket.TicketManagement.WebUI;
using GloboTicket.TicketManagement.WebUI.Auth;
using GloboTicket.TicketManagement.WebUI.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]) });

builder.Services.AddHttpClient<IApiClient, ApiClient>(client => client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]));

await builder.Build().RunAsync();
