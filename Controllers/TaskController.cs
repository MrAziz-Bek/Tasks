namespace Tasks.Controllers;

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
    [ActionName(nameof(CreateTask))]
    public async Task<IActionResult> CreateTask([FromBody] NewTask newTask)
    {
        var taskEntity = newTask.ToTaskEntity();
        var insertResult = await _storage.InsertTaskAsync(taskEntity);

        if (insertResult.IsSuccess)
        {
            return CreatedAtAction(nameof(CreateTask), taskEntity);
        }
        return StatusCode((int)HttpStatusCode.InternalServerError, new { message = insertResult.exception.Message });
    }
    [HttpGet]
    public async Task<IActionResult> GetTask([FromQuery] TaskQuery taskQuery)
    {
        var task = await _storage.GetTaskAsync(title: taskQuery.Title, id: taskQuery.Id);
        if (task.Any())
        {
            return Ok(task);
        }
        return NotFound($"This Task doesn't exist");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromBody] UpdatedTask updatedTask)
    {
        var entity = updatedTask.ToTaskEntity();
        var updatedResult = await _storage.UpdateTaskAsync(entity);

        if (updatedResult.IsSuccess)
        {
            return Ok();
        }
        return BadRequest(updatedResult.exception.Message);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid id)
    {
        var deletedTask = await _storage.RemoveTaskAsync(id);
        if (deletedTask.IsSuccess)
        {
            return Ok();
        }
        return BadRequest();
    }

}