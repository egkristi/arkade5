using Arkivverket.Arkade.Core.Base;
using Microsoft.OpenApi.Models;
using Arkivverket.Arkade.API.Services;
using Arkivverket.Arkade.API.Filters;
using Arkivverket.Arkade.API.Middleware;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ArchiveValidationFilter>();
});

builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { 
        Title = "Arkade API", 
        Version = "v1",
        Description = "REST API for Arkade archive processing functionality"
    });
});

// Register Arkade services
builder.Services.AddScoped<ArkadeApi>();
builder.Services.AddScoped<TestSessionFactory>();
builder.Services.AddScoped<TestEngineFactory>();
builder.Services.AddScoped<TestOperationService>();
// Add other required services here

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Add health check endpoint
app.MapHealthChecks("/health");

app.MapControllers();

// Configure temporary directory from environment variable
var tempDir = Environment.GetEnvironmentVariable("TempDirectory") ?? Path.Combine(Path.GetTempPath(), "arkade_tests");
Directory.CreateDirectory(tempDir);

app.Run();
