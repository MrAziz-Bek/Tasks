namespace Tasks.Mapper
{
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
    }
}