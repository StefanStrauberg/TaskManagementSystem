namespace TaskService.Application.DTOs.TaskEntityDTOs;

/// <summary>
/// Represents a task entity DTO with detailed properties.
/// </summary>
public class TaskEntityDTO : BaseTaskEntityDTO, IMapWith<TaskEntity>
{
  /// <summary>
  /// Gets or sets the unique identifier for the entity.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Defines the mapping between TaskEntityDTO and TaskEntity using Mapster.
  /// Specifies rules for property transformation when converting TaskEntity to BaseTaskEntityDTO.
  /// </summary>
  /// <param name="config">The Mapster configuration object used for defining mappings.</param>
  void IMapWith<TaskEntity>.Mapping(TypeAdapterConfig config)
  {
    config.NewConfig<TaskEntity, TaskEntityDTO>()
          .Map(dst => dst.Id, src => src.Id);
  }
}
