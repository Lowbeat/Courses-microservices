using Microsoft.AspNetCore.Mvc;
using Orchestrator.Services;
using SharedModels;

namespace Orchestrator.Controllers;

[ApiController]
[Route("[controller]")]
public class OrchestratorController : ControllerBase
{
    private readonly QueueManager _queueManager;

    public OrchestratorController(QueueManager queueManager)
    {
        _queueManager = queueManager;
    }

    [HttpPost("notify")]
    public IActionResult NotifyProductAvailable([FromBody] ProductAvailabilityEvent availabilityEvent)
    {
        _queueManager.ProcessProductEvent(availabilityEvent);
        return Ok();
    }

    [HttpGet("queues")]
    public IActionResult GetQueues()
    {
        return Ok(_queueManager.GetAllQueues());
    }
}
