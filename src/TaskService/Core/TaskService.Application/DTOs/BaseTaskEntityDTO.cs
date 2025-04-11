namespace TaskService.Application.DTOs;

/// <summary>
/// Represents a base task entity DTO with base properties.
/// </summary>
public class BaseTaskEntityDTO : IMapWith<TaskEntity>
{
  /// <summary>
  /// Gets or sets the name of the task.
  /// Provides the name of the task's purpose.
  /// </summary>
  public string Name { get; set; } = string.Empty;

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
  /// Gets or sets the name or identifier of the Executor assigned to the task.
  /// Represents the person responsible for performing the task.
  /// </summary>
  public string Executor { get; set; } = string.Empty;

  /// <summary>
  /// Defines the mapping between BaseTaskEntityDTO and TaskEntity using Mapster.
  /// Specifies rules for property transformation when converting TaskEntity to BaseTaskEntityDTO.
  /// </summary>
  /// <param name="config">The Mapster configuration object used for defining mappings.</param>
  
  void IMapWith<TaskEntity>.Mapping(TypeAdapterConfig config)
  {
    config.NewConfig<TaskEntity, BaseTaskEntityDTO>()
          .Map(dst => dst.Name, src => src.Name)
          .Map(dst => dst.Description, src => src.Description)
          .Map(dst => dst.Status, src => src.Status)
          .Map(dst => dst.Priority, src => src.Priority)
          .Map(dst => dst.Started, src => src.Started)
          .Map(dst => dst.Deadline, src => src.Deadline)
          .Map(dst => dst.Author, src => src.Author)
          .Map(dst => dst.Executor, src => src.Executor);
  }
}
