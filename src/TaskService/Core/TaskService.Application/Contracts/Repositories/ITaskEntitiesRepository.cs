namespace TaskService.Application.Contracts.Repositories;

/// <summary>
/// Represents a repository interface for managing TaskEntity objects.
/// Extends the generic repository interface to include task-specific query methods.
/// </summary>
public interface ITaskEntitiesRepository : IGenericRepository<TaskEntity>
{
  /// <summary>
  /// Asynchronously retrieves a collection of TaskEntity objects based on the specified request parameters.
  /// </summary>
  /// <param name="reqParams">The parameters for filtering, sorting, and paging the tasks.</param>
  /// <param name="token">A token to cancel the operation if necessary.</param>
  /// <returns>A collection of TaskEntity objects matching the criteria.</returns>
  Task<IEnumerable<TaskEntity>> GetTaskEntitiesByReqParamsAsync(RequestParameters reqParams,
                                                                CancellationToken token);

  /// <summary>
  /// Asynchronously retrieves a single TaskEntity object based on the specified request parameters.
  /// </summary>
  /// <param name="reqParams">The parameters for filtering and querying the task.</param>
  /// <param name="token">A token to cancel the operation if necessary.</param>
  /// <returns>A single TaskEntity object matching the criteria.</returns>
  Task<TaskEntity> GetTaskEntityByReqParamsAsync(RequestParameters reqParams,
                                                 CancellationToken token);
  
  /// <summary>
  /// Asynchronously retrieves the count of TaskEntity objects based on the specified request parameters.
  /// </summary>
  /// <param name="reqParams">The parameters for filtering and counting the tasks.</param>
  /// <param name="token">A token to cancel the operation if necessary.</param>
  /// <returns>The count of TaskEntity objects matching the criteria.</returns>
  Task<int> GetCountTaskEntitiesByReqParamsAsync(RequestParameters reqParams,
                                                 CancellationToken token);
}
