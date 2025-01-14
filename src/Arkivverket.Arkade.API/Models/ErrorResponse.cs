namespace Arkivverket.Arkade.API.Models;

public class ErrorResponse
{
    public string Type { get; set; }
    public string Message { get; set; }
    public string Details { get; set; }
    public string TraceId { get; set; }
    public IDictionary<string, string[]> ValidationErrors { get; set; }

    public ErrorResponse(string type, string message, string details = null)
    {
        Type = type;
        Message = message;
        Details = details;
    }
}
