using System.Net;
using System.Text.Json;
using Arkivverket.Arkade.API.Exceptions;
using Arkivverket.Arkade.API.Models;

namespace Arkivverket.Arkade.API.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _environment;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger,
        IHostEnvironment environment)
    {
        _next = next;
        _logger = logger;
        _environment = environment;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        
        var errorResponse = exception switch
        {
            ArkadeApiException arkadeEx => HandleArkadeApiException(arkadeEx, response),
            _ => HandleUnknownException(exception, response)
        };

        errorResponse.TraceId = context.TraceIdentifier;

        var result = JsonSerializer.Serialize(errorResponse);
        await response.WriteAsync(result);
    }

    private ErrorResponse HandleArkadeApiException(ArkadeApiException exception, HttpResponse response)
    {
        switch (exception)
        {
            case ArchiveValidationException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case TestOperationNotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            case ArchiveProcessingException:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        _logger.LogError(exception, "Arkade API error occurred: {Message}", exception.Message);

        return new ErrorResponse(
            exception.Type,
            exception.Message,
            _environment.IsDevelopment() ? exception.Details : null
        );
    }

    private ErrorResponse HandleUnknownException(Exception exception, HttpResponse response)
    {
        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        _logger.LogError(exception, "An unexpected error occurred");

        return new ErrorResponse(
            "UnexpectedError",
            "An unexpected error occurred",
            _environment.IsDevelopment() ? exception.ToString() : null
        );
    }
}
