namespace TaskService.Application.Contracts.Repositories;

/// <summary>
/// Represents a generic repository interface for CRUD operations and querying entities.
/// Provides a standardized approach to interacting with the data layer for domain entities.
/// </summary>
/// <typeparam name="T">
/// The type of entity the repository will manage. Must inherit from <see cref="BaseEntity"/>.
/// </typeparam>
public interface IGenericRepository<T>
  where T : BaseEntity
{
  /// <summary>
  /// Asynchronously retrieves all entities in the repository.
  /// </summary>
  /// <param name="token">A token to cancel the operation.</param>
  /// <returns>An enumerable of all entities.</returns>
  Task<IEnumerable<T>> GetAllAsync(CancellationToken token);

  /// <summary>
  /// Asynchronously retrieves the first entity matching the specified identifier.
  /// </summary>
  /// <param name="id">The unique identifier of the entity.</param>
  /// <param name="token">A token to cancel the operation.</param>
  /// <returns>The entity matching the identifier.</returns>
  Task<T> FirstByIdAsync(Guid id,
                         CancellationToken token);

  /// <summary>
  /// Inserts a single entity into the repository.
  /// </summary>
  /// <param name="entity">The entity to insert.</param>
  void InsertOne(T entity);

  /// <summary>
  /// Inserts multiple entities into the repository in a single operation.
  /// </summary>
  /// <param name="entities">The entities to insert.</param>
  void InsertMany(IEnumerable<T> entities);

  /// <summary>
  /// Replaces a single entity in the repository with an updated version.
  /// </summary>
  /// <param name="entity">The updated entity to replace.</param>
  void ReplaceOne(T entity);

  /// <summary>
/// Replaces multiple entities in the repository with updated versions.
  /// </summary>
  /// <param name="entities">The updated entities to replace.</param>
  void ReplaceMany(IEnumerable<T> entities);

  /// <summary>
  /// Deletes a single entity from the repository.
  /// </summary>
  /// <param name="entity">The entity to delete.</param>
  void DeleteOne(T entity);

  /// <summary>
  /// Deletes multiple entities from the repository.
  /// </summary>
  /// <param name="entities">The entities to delete.</param>
  void DeleteMany(IEnumerable<T> entities);

  /// <summary>
  /// Asynchronously determines whether any entities exist in the repository.
  /// </summary>
  /// <param name="token">A token to cancel the operation.</param>
  /// <returns><c>true</c> if any entities exist; otherwise, <c>false</c>.</returns>
  Task<bool> AnyAsync(CancellationToken token);

  /// <summary>
  /// Asynchronously determines whether any entity exists in the repository by its identifier.
  /// </summary>
  /// <param name="token">A token to cancel the operation.</param>
  /// <returns><c>true</c> if an entity exists; otherwise, <c>false</c>.</returns>
  Task<bool> AnyByIdAsync(CancellationToken token);

  /// <summary>
  /// Asynchronously retrieves the total count of all entities in the repository.
  /// </summary>
  /// <param name="token">A token to cancel the operation if necessary.</param>
  /// <returns>The total count of entities as an integer.</returns>
  Task<int> GetCountAsync(CancellationToken token);
}
