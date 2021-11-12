namespace Tasks.Controllers;
[ApiController]
[Route("[controller]")]
public class TaskController
{
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }
}