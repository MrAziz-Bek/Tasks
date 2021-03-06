namespace Tasks.Data;
public class TaskDbContext : DbContext
{
    public DbSet<Tasks.Entity.Task>? Tasks { get; set; }

    public TaskDbContext(DbContextOptions options)
        : base(options) { }
}