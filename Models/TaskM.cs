namespace Tasks.Models;
public class TaskM
{
    public TaskM(string title, string description, string tags, DateTimeOffset onADay, DateTimeOffset atATime, ETaskStatus status, ETaskRepeat repeat, ETaskPriority priority, string location, string url)
    {
        Title = title;
        Description = description;
        Tags = tags;
        OnADay = onADay;
        AtATime = atATime;
        Status = status;
        Repeat = repeat;
        Priority = priority;
        Location = location;
        Url = url;
    }

    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Tags { get; set; }

    public DateTimeOffset OnADay { get; set; }

    public DateTimeOffset AtATime { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tasks.Models.ETaskStatus? Status { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tasks.Models.ETaskRepeat? Repeat { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tasks.Models.ETaskPriority? Priority { get; set; }

    public string Location { get; set; }

    public string Url { get; set; }
}