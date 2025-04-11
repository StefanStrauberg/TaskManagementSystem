namespace TaskService.Application.DTOs;

/// <summary>
/// Represents a update task entity DTO with necessary properties.
/// </summary>
public class UpdateTaskEntityDTO : BaseModificationTaskEntityDTO, IMapWith<TaskEntity>
{ 
  /// <summary>
  /// Gets or sets the unique identifier for the entity.
  /// </summary>
  public Guid Id { get; set; }

  void IMapWith<TaskEntity>.Mapping(TypeAdapterConfig config)
  {
    config.NewConfig<UpdateTaskEntityDTO, TaskEntity>()
          .Map(dst => dst.Id, src => src.Id);
  }
}
