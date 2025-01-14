using Microsoft.AspNetCore.Mvc.Filters;
using Arkivverket.Arkade.API.Exceptions;

namespace Arkivverket.Arkade.API.Filters;

public class ArchiveValidationFilter : IAsyncActionFilter
{
    private readonly ILogger<ArchiveValidationFilter> _logger;
    private readonly long _maxFileSize = 1024 * 1024 * 500; // 500MB
    private readonly string[] _allowedExtensions = new[] { ".tar", ".zip", ".siard" };

    public ArchiveValidationFilter(ILogger<ArchiveValidationFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.TryGetValue("archiveFile", out var archiveFileObj) || 
            archiveFileObj is not IFormFile archiveFile)
        {
            throw new ArchiveValidationException("No archive file was provided");
        }

        // Validate file size
        if (archiveFile.Length > _maxFileSize)
        {
            throw new ArchiveValidationException(
                "File size exceeds maximum limit",
                $"Maximum allowed file size is {_maxFileSize / (1024 * 1024)}MB");
        }

        // Validate file extension
        var extension = Path.GetExtension(archiveFile.FileName).ToLowerInvariant();
        if (!_allowedExtensions.Contains(extension))
        {
            throw new ArchiveValidationException(
                "Invalid file type",
                $"Allowed file types are: {string.Join(", ", _allowedExtensions)}");
        }

        await next();
    }
}
