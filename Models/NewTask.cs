namespace Tasks.Models;
public class NewTask
{
    [MaxLength(255)]
    [Required]
    public string? Title { get; set; }

    [MaxLength(1024)]
    public string? Description { get; set; }

    public List<string>? Tags { get; set; }

    public DateTimeOffset OnADay { get; set; }

    public DateTimeOffset AtATime { get; set; }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tasks.Models.ETaskStatus Status { get; set; }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tasks.Models.ETaskRepeat Repeat { get; set; }


    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Tasks.Models.ETaskPriority Priority { get; set; }

    public TaskLocation? Location { get; set; }

    public string? Url { get; set; }
}