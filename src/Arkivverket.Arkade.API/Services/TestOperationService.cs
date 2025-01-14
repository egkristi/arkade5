using System.Collections.Concurrent;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.API.Models;
using Arkivverket.Arkade.API.Exceptions;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Arkivverket.Arkade.API.Services;

public class TestOperationService
{
    private readonly ArkadeApi _arkadeApi;
    private readonly ILogger<TestOperationService> _logger;
    private readonly string _tempDirectory;
    private static readonly ConcurrentDictionary<string, TestOperation> _operations = new();

    public TestOperationService(ArkadeApi arkadeApi, ILogger<TestOperationService> logger, IConfiguration configuration)
    {
        _arkadeApi = arkadeApi;
        _logger = logger;
        _tempDirectory = Environment.GetEnvironmentVariable("TempDirectory") ?? 
                        Path.Combine(Path.GetTempPath(), "arkade_tests");
    }

    public async Task<string> StartTestOperation(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new ArchiveValidationException("Archive file not found", $"File path: {filePath}");
        }

        var testId = Guid.NewGuid().ToString();
        var operation = new TestOperation
        {
            Id = testId,
            Status = "Processing",
            StartTime = DateTime.UtcNow
        };
        
        _operations.TryAdd(testId, operation);

        // Start the test operation asynchronously
        _ = Task.Run(async () =>
        {
            var testDir = Path.Combine(_tempDirectory, testId);
            Directory.CreateDirectory(testDir);

            try
            {
                var archiveFile = new ArchiveFile(filePath);
                var testSession = _arkadeApi.CreateTestSession(archiveFile);

                string disqualifyingCause;
                if (!testSession.IsTestableArchive(out disqualifyingCause))
                {
                    operation.Status = "Failed";
                    operation.Messages.Add($"Archive is not testable: {disqualifyingCause}");
                    operation.EndTime = DateTime.UtcNow;
                    return;
                }

                _arkadeApi.RunTests(testSession);

                // Update operation with results
                operation.Status = "Completed";
                operation.EndTime = DateTime.UtcNow;
                operation.Success = testSession.TestSuite?.TestResults?.All(r => r.Status == TestStatus.Success) ?? false;
                
                if (testSession.TestSuite?.TestResults != null)
                {
                    foreach (var result in testSession.TestSuite.TestResults)
                    {
                        operation.Messages.Add($"Test {result.TestName}: {result.Status} - {result.Message}");
                    }
                }

                foreach (var logEntry in testSession.GetLogEntries())
                {
                    operation.Messages.Add(logEntry.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during test operation");
                operation.Status = "Failed";
                operation.Messages.Add($"Error: {ex.Message}");
                operation.EndTime = DateTime.UtcNow;
                throw new ArchiveProcessingException("Failed to process archive", ex.Message, ex);
            }
            finally
            {
                // Clean up temporary files
                try
                {
                    if (Directory.Exists(testDir))
                    {
                        Directory.Delete(testDir, true);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error cleaning up temporary files");
                }
            }
        });

        return testId;
    }

    public TestResult GetTestStatus(string testId)
    {
        if (!_operations.TryGetValue(testId, out var operation))
        {
            throw new TestOperationNotFoundException(testId);
        }

        return new TestResult
        {
            TestId = operation.Id,
            Status = operation.Status,
            StartTime = operation.StartTime,
            EndTime = operation.EndTime,
            Messages = operation.Messages,
            Success = operation.Success
        };
    }
}

public class TestOperation
{
    public string Id { get; set; }
    public string Status { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public List<string> Messages { get; set; } = new();
    public bool Success { get; set; }
}
