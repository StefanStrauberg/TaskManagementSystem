namespace TaskService.Domain;

public class TaskEntity : BaseEntity
{
  public string Description { get; set; } = string.Empty;
  public Status Status { get; set; }
  public Priority Priority { get; set; }
  public DateTime Started { get; set; }
  public DateTime Deadline { get; set; }
  public string Author { get; set; } = string.Empty;
  public string Contractor { get; set; } = string.Empty;
}
public enum Status
{
  Open,
  InProgress,
  Completed
}

public enum Priority
{
  Low,
  Medium,
  High
}
