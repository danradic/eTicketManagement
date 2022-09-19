using GloboTicket.TicketManagement.BlazorWasm;
using GloboTicket.TicketManagement.Infrastructure;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddInfrastructureServicesForBlazorWasm();

await builder.Build().RunAsync();
