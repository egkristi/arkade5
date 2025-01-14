namespace Arkivverket.Arkade.API.Exceptions;

public class ArkadeApiException : Exception
{
    public string Type { get; }
    public string Details { get; }

    public ArkadeApiException(string type, string message, string details = null, Exception innerException = null) 
        : base(message, innerException)
    {
        Type = type;
        Details = details;
    }
}

public class ArchiveValidationException : ArkadeApiException
{
    public ArchiveValidationException(string message, string details = null) 
        : base("ValidationError", message, details)
    {
    }
}

public class ArchiveProcessingException : ArkadeApiException
{
    public ArchiveProcessingException(string message, string details = null, Exception innerException = null) 
        : base("ProcessingError", message, details, innerException)
    {
    }
}

public class TestOperationNotFoundException : ArkadeApiException
{
    public TestOperationNotFoundException(string testId) 
        : base("NotFound", $"Test operation with ID {testId} was not found")
    {
    }
}
