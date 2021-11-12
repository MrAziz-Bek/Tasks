using System.Net;
namespace Tasks.Controller;
[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;
    private readonly IStorageService _storage;

    public TaskController(ILogger<TaskController> logger, IStorageService storage)
    {
        _logger = logger;
        _storage = storage;
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> CreateTask([FromBody] NewTask newTask)
    {
        var taskEntity = newTask.ToTaskEntity();
        var insertResult = await _storage.InsertTaskAsync(taskEntity);

        if (insertResult.IsSuccess)
        {
            return CreatedAtAction("Create Task", taskEntity);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.exception.Message });
    }
}