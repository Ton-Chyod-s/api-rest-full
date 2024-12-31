using System.Text.Json.Serialization;
using DiarioOficial.API.Endpoints;
using Microsoft.AspNetCore.Mvc;
using DiarioOficial.Application.Extensions;
using DiarioOficial.Infraestructure.Extensions;
using DiarioOficial.API.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Public Records API",
        Version = "v1",
        Description = "API for accessing and managing public records and official diaries.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Dev-Ton-Chyod-$",
            Email = "hix_x@hotmail.com",
            Url = new Uri("https://github.com/Ton-Chyod-s"),
        }
    });
});

var connectionString = builder.Configuration.GetConnectionString("OfficialDiaryDb");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'OfficialDiaryDb' not found.");
}

var configuration = builder.Configuration; 

builder.Services
    .AddSingleton(connectionString)
    .ConfigureServices(builder.Configuration)
    .ConfigureRepositories(builder.Configuration)
    .AddUseCases();

builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app
    .MapAuthenticationEndpoints()
    .MapOfficialDiaryEndpoints()
    .MapMailEndpoints()
    .MapPersonEndpoints();

app.Run();
