using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Api.Utility;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    { 
        Version = "v1",
        Title = "GloboTicket Ticket Management API" 
    });
    c.OperationFilter<FileResultContentTypeOperationFilter>();
});

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GloboTicket Ticket Management API");
});

app.UseCors();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
