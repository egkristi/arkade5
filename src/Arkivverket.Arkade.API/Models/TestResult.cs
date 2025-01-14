namespace Arkivverket.Arkade.API.Models;

public class TestResult
{
    public string TestId { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public List<string> Messages { get; set; } = new();
    public bool Success { get; set; }
}
