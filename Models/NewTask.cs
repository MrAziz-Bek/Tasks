namespace tasks.models;
public class NewTask
{
    [MaxLength(255)]
    [Required]
    public string Title { get; set; }

    [MaxLength(1024)]
    public string Description { get; set; }

    public List<string> Tags { get; set; }

    public DateTimeOffset OnADay { get; set; }

    public DateTimeOffset AtATime { get; set; }

    [JsonConverter]
    public Tasks.Models.ETaskStatus Status { get; set; }

    public Tasks.Models.ETaskRepeat Repeat { get; set; }

    public Tasks.Models.ETaskPriority Priority { get; set; }

    public TaskLocation Location { get; set; }

    public string Url { get; set; }
}