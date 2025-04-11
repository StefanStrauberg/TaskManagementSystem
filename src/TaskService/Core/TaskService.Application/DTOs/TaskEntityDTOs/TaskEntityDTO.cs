namespace TaskService.Application.DTOs.TaskEntityDTOs;

/// <summary>
/// Represents a task entity DTO with detailed properties.
/// </summary>
public class TaskEntityDTO : BaseTaskEntityDTO
{
  /// <summary>
  /// Gets or sets the unique identifier for the entity.
  /// </summary>
  public Guid Id { get; set; }
}
