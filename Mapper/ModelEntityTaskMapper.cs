namespace Tasks.Mapper;
public static class ModelEntityTaskMapper
{
    public static Entity.Task ToTaskEntity(this Models.NewTask newTask)
    {
        return new Entity.Task(
            title: newTask.Title,
            description: newTask.Description,
            tags: newTask.Tags is null ? string.Empty : string.Join(',', newTask.Tags),
            onADay: newTask.OnADay,
            atATime: newTask.AtATime,
            status: newTask.Status.ToEntityETaskStatus(),
            repeat: newTask.Repeat.ToEntityETaskRepeat(),
            priority: newTask.Priority.ToEntityETaskPriority(),
            location: newTask.Location is null ? string.Empty : string.Format($"{newTask.Location.latitude},{newTask.Location.longitude}"),
            url: newTask.Url
        );
    }
    public static Entity.Task ToTaskEntity(this Models.UpdatedTask updatedTask)
    {
        return new Entity.Task(
            title: updatedTask.Title,
            description: updatedTask.Description,
            tags: updatedTask.Tags is null ? string.Empty : string.Join(',', updatedTask.Tags),
            onADay: updatedTask.OnADay,
            atATime: updatedTask.AtATime,
            status: updatedTask.Status.Value.ToEntityETaskStatus(),
            repeat: updatedTask.Repeat.Value.ToEntityETaskRepeat(),
            priority: updatedTask.Priority.Value.ToEntityETaskPriority(),
            location: updatedTask.Location is null ? string.Empty : string.Format($"{updatedTask.Location.latitude},{updatedTask.Location.longitude}"),
            url: updatedTask.Url)
        {
            Id = updatedTask.Id
        };
    }
}