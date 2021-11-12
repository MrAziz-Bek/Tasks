namespace Tasks.Models;
public class UpdatedTask
{
    [Required]
    public Guid Id { get; set; }

    [MaxLength(255)]
    [Required]
    public string Title { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }

    public List<string> Tags { get; set; }

    public DateTimeOffset OnADay { get; set; }

    public DateTimeOffset AtATime { get; set; }

    public Models.ETaskStatus? Status { get; set; }

    public Models.ETaskRepeat? Repeat { get; set; }

    public Models.ETaskPriority? Priority { get; set; }

    public TaskLocation Location { get; set; }

    public string Url { get; set; }
}