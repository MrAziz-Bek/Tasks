using Tasks.Entity;

namespace tasks.services
{
    public interface IStorageService
    {
        Task<(bool IsSuccess, Exception exception)> InsertTaskAsync(Tasks.Entity.Task task);

        Task<(bool IsSuccess, Exception exception)> UpdateTaskAsync(Tasks.Entity.Task task);

        Task<(bool IsSuccess, Exception exception)> RemoveTaskAsync(Tasks.Entity.Task task);

        Task<List<Tasks.Entity.Task>> GetTaskAsync(
            Guid id = default(Guid),
            string? title = default(string),
            string? description = default(string),
            string? tags = default(string),
            ETaskStatus? status = null,
            ETaskRepeat? repeat = null,
            ETaskPriority? priority = null,
            DateTimeOffset onADay = default(DateTimeOffset),
            DateTimeOffset atATime = default(DateTimeOffset),
            string? location = default(string),
            string? url = default(string)
        );
    }
}