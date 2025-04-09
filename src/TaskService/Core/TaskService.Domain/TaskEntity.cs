namespace TaskService.Domain;

/// <summary>
/// Represents a task entity with detailed properties to manage and track tasks.
/// </summary>
public class TaskEntity : BaseEntity
{
  /// <summary>
  /// Gets or sets the description of the task.
  /// Provides details about the task's purpose or requirements.
  /// </summary>
  public string Description { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the current status of the task.
  /// Tracks the task's progress using the Status enum.
  /// </summary>
  public Status Status { get; set; }

  /// <summary>
  /// Gets or sets the priority level of the task.
  /// Indicates how urgent or important the task is using the Priority enum.
  /// </summary>
  public Priority Priority { get; set; }

  /// <summary>
  /// Gets or sets the start date and time of the task.
  /// Specifies when the task was initiated.
  /// </summary>
  public DateTime Started { get; set; }

  /// <summary>
  /// Gets or sets the deadline of the task.
  /// Specifies the date and time by which the task should be completed.
  /// </summary>
  public DateTime Deadline { get; set; }

  /// <summary>
  /// Gets or sets the name or identifier of the task's author.
  /// Represents the creator or owner of the task.
  /// </summary>
  public string Author { get; set; } = string.Empty;

  /// <summary>
  /// Gets or sets the name or identifier of the contractor assigned to the task.
  /// Represents the person responsible for performing the task.
  /// </summary>
  public string Contractor { get; set; } = string.Empty;
}
