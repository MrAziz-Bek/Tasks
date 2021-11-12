namespace Tasks.Services;
public class DbStorageService : IStorageService
{
    private readonly ILogger<DbStorageService> _logger;
    private readonly TaskDbContext? _context;

    public DbStorageService(ILogger<DbStorageService> logger, TaskDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task<(bool IsSuccess, Exception exception)> InsertTaskAsync(Entity.Task task)
    {
        try
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Task inserted in DB: {task.Id}");
            return (true, null);
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Inserting Task to DB failed: {e.Message}", e);
            return (false, e);
        }
    }
    public async Task<(bool IsSuccess, Exception exception)> RemoveTaskAsync(Entity.Task task)
    {
        try
        {
            if (await _context.Tasks.AnyAsync(t => t.Id == task.Id))
            {
                _context?.Tasks?.Remove(task);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Task removed from DB: {task.Id}");
                return (true, null);
            }
            else
            {
                return (false, new Exception($"Task with given ID: {task.Id} doesn't exist!"));
            }
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Removing task from DB failed: {task.Id}");
            return (false, e);
        }
    }

    public async Task<(bool IsSuccess, Exception exception)> UpdateTaskAsync(Entity.Task task)
    {
        try
        {
            if (await _context.Tasks.AnyAsync(t => t.Id == task.Id))
            {
                _context.Tasks.Update(task);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Task updated in DB: {task.Id}");
                return (true, null);
            }
            else
            {
                return (false, new Exception($"Task with given ID: {task.Id} doesn't exist"));
            }
        }
        catch (Exception e)
        {
            _logger.LogInformation($"Updating task in DB failed: {task.Id}");
            return (false, e);
        }
    }

    public async Task<List<Entity.Task>> GetTaskAsync(Guid id = default(Guid), string? title = default(string), string? description = default(string), string? tags = default(string), Entity.ETaskStatus? status = null, Entity.ETaskRepeat? repeat = null, Entity.ETaskPriority? priority = null, DateTimeOffset onADay = default(DateTimeOffset), DateTimeOffset atATime = default(DateTimeOffset), string? location = default(string), string? url = default(string))
    {
        var tasks = _context?.Tasks?.AsNoTracking();
        if (id != default(Guid))
        {
            tasks = tasks?.Where(t => t.Title.ToLower().Equals(title.ToLower()));
        }
        if (title != default(string))
        {
            tasks = tasks?.Where(t => t.Title.ToLower().Equals(title.ToLower()) || t.Title.ToLower().Contains(title.ToLower()));
        }
        if (tags != default(string))
        {
            tasks = tasks?.Where(t => t.Tags.ToLower().Equals(tags.ToLower()));
        }
        if (description != default(string))
        {
            tasks = tasks?.Where(t => t.Description == description);
        }
        if (priority.HasValue)
        {
            tasks = tasks?.Where(t => t.Priority == priority.Value);
        }
        if (status.HasValue)
        {
            tasks = tasks?.Where(t => t.Status == status.Value);
        }
        if (repeat.HasValue)
        {
            tasks = tasks?.Where(t => t.Repeat == repeat.Value);
        }
        if (onADay != default(DateTimeOffset))
        {
            tasks = tasks?.Where(t => t.OnADay == onADay);
        }
        if (atATime != default(DateTimeOffset))
        {
            tasks = tasks?.Where(t => t.AtATime == atATime);
        }
        if (location != default(string))
        {
            tasks = tasks?.Where(t => t.Location == location);
        }
        if (url != default(string))
        {
            tasks = tasks?.Where(t => t.Url == url);
        }
        return await tasks.ToListAsync();
    }
}