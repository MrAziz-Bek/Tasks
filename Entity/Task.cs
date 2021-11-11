namespace Tasks.Entity;
public class Task
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    [MaxLength(255)]
    [Required]
    public string Title { get; set; }
    
    [MaxLength(1024)]
    public string Description { get; set; }
    
    [MaxLength(1024)]
    public string Tags { get; set; }
    
    public DateTimeOffset OnADay { get; set; }
    
    public DateTimeOffset AtATime { get; set; }
    
    public ETaskStatus Status { get; set; }
    
    public ETaskRepeat Repeat { get; set; }
    
    public ETaskPriority Priority { get; set; }
    
    public string Location { get; set; }
    
    public string Url { get; set; }

    [Obsolete("Used only for Entity binding")]
    public Task() { }

    public Task(Guid id, string title, string description, string tags, DateTimeOffset onADay, DateTimeOffset atATime, ETaskStatus status, ETaskRepeat repeat, ETaskPriority priority, string location, string url)
    {
        Id = id;
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
}