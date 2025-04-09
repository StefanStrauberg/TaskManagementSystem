namespace TaskService.Domain.Common;

/// <summary>
/// Represents a base entity class that provides common properties for all domain models.
/// </summary>
public class BaseEntity
{
  /// <summary>
  /// Gets or sets the unique identifier for the entity.
  /// </summary>
  public Guid Id { get; set; }

  /// <summary>
  /// Gets or sets the date and time when the entity was created.
  /// </summary>
  public DateTime Created { get; set; }

  /// <summary>
  /// Gets or sets the date and time when the entity was last updated.
  /// </summary>
  public DateTime Updated { get; set; }
}
