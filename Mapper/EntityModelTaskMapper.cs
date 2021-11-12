namespace Tasks.Mapper;
public static class EntityModelTaskMapper
{
    public static Tasks.Models.TaskM ToTaskModel(this Tasks.Entity.Task task)
    {
        return new Tasks.Models.TaskM(
            title: task.Title,
            description: task.Description,
            tags: task.Tags,
            onADay: task.OnADay,
            atATime: task.AtATime,
            status: task.Status.ToModelETaskStatus(),
            repeat: task.Repeat.ToModelETaskRepeat(),
            priority: task.Priority.ToModelETaskPriority(),
            location: task.Location,
            url: task.Url
        );
    }
    public static Tasks.Models.ETaskStatus ToModelETaskStatus(this Tasks.Entity.ETaskStatus? status)
    {
        return status switch
        {
            Tasks.Entity.ETaskStatus.Completed => Tasks.Models.ETaskStatus.Completed,
            Tasks.Entity.ETaskStatus.InProgress => Tasks.Models.ETaskStatus.InProgress,
            Tasks.Entity.ETaskStatus.Postponed => Tasks.Models.ETaskStatus.Postponed,
            _ => Tasks.Models.ETaskStatus.None
        };
    }
    public static Tasks.Models.ETaskRepeat ToModelETaskRepeat(this Tasks.Entity.ETaskRepeat? repeat)
    {
        return repeat switch
        {
            Tasks.Entity.ETaskRepeat.Hourly => Tasks.Models.ETaskRepeat.Hourly,
            Tasks.Entity.ETaskRepeat.Daily => Tasks.Models.ETaskRepeat.Daily,
            Tasks.Entity.ETaskRepeat.Weekly => Tasks.Models.ETaskRepeat.Weekly,
            Tasks.Entity.ETaskRepeat.Monthly => Tasks.Models.ETaskRepeat.Monthly,
            Tasks.Entity.ETaskRepeat.Yearly => Tasks.Models.ETaskRepeat.Yearly,
            _ => Tasks.Models.ETaskRepeat.Never
        };
    }
    public static Tasks.Models.ETaskPriority ToModelETaskPriority(this Tasks.Entity.ETaskPriority? priority)
    {
        return priority switch
        {
            Tasks.Entity.ETaskPriority.High => Tasks.Models.ETaskPriority.High,
            Tasks.Entity.ETaskPriority.Low => Tasks.Models.ETaskPriority.Low,
            Tasks.Entity.ETaskPriority.Mid => Tasks.Models.ETaskPriority.Mid,
            _ => Tasks.Models.ETaskPriority.None
        };
    }
}