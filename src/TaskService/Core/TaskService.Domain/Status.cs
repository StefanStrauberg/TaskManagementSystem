namespace TaskService.Domain;

/// <summary>
/// Defines possible states of a task.
/// </summary>
public enum Status
{
  /// <summary>
  /// Indicates that the task is open and has not yet started.
  /// </summary>
  Open,

  /// <summary>
  /// Indicates that the task is currently in progress.
  /// </summary>
  InProgress,

  /// <summary>
  /// Indicates that the task has been completed successfully.
  /// </summary>
  Completed
}
