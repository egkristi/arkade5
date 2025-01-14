using Microsoft.AspNetCore.Mvc;
using Arkivverket.Arkade.Core.Base;
using Arkivverket.Arkade.API.Services;
using Arkivverket.Arkade.API.Models;

namespace Arkivverket.Arkade.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArchiveController : ControllerBase
{
    private readonly TestOperationService _testOperationService;
    private readonly ILogger<ArchiveController> _logger;

    public ArchiveController(TestOperationService testOperationService, ILogger<ArchiveController> logger)
    {
        _testOperationService = testOperationService;
        _logger = logger;
    }

    [HttpPost("test")]
    public async Task<IActionResult> TestArchive([FromForm] IFormFile archiveFile)
    {
        try
        {
            if (archiveFile == null || archiveFile.Length == 0)
                return BadRequest("No file uploaded");

            // Create a temporary directory for the upload
            var tempDir = Path.Combine(Path.GetTempPath(), "arkade_tests", Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);
            var tempPath = Path.Combine(tempDir, archiveFile.FileName);

            using (var stream = new FileStream(tempPath, FileMode.Create))
            {
                await archiveFile.CopyToAsync(stream);
            }

            var testId = await _testOperationService.StartTestOperation(tempPath);

            return Ok(new { testId, message = "Archive testing initiated" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing archive");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("status/{testId}")]
    public IActionResult GetTestStatus(string testId)
    {
        try
        {
            var result = _testOperationService.GetTestStatus(testId);
            if (result == null)
                return NotFound($"No test operation found with ID: {testId}");

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking test status");
            return StatusCode(500, "Internal server error");
        }
    }
}
