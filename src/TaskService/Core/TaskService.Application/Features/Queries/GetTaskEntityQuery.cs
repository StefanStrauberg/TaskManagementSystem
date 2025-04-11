namespace TaskService.Application.Features.Queries;

/// <summary>
/// Represents a query to retrieve a single TaskEntity by its unique identifier.
/// </summary>
/// <param name="Id">The unique identifier for the requested TaskEntity.</param>
public record GetTaskEntityQuery(Guid Id) : IQuery<TaskEntityDTO>;

/// <summary>
/// Handles the GetTaskEntityQuery by accessing the repository and adapting the result to a DTO.
/// </summary>
internal class GetTaskEntityQueryHandler(IUnitOfWork unitOfWork)
  : IQueryHandler<GetTaskEntityQuery, TaskEntityDTO>
{
  /// <summary>
  /// Processes the GetTaskEntityQuery to retrieve and return the corresponding TaskEntityDTO.
  /// </summary>
  /// <param name="request">The query containing the unique identifier.</param>
  /// <param name="cancellationToken">Token to cancel the operation if needed.</param>
  /// <returns>The TaskEntityDTO representing the requested TaskEntity.</returns>
  async Task<TaskEntityDTO> IRequestHandler<GetTaskEntityQuery, TaskEntityDTO>.Handle(GetTaskEntityQuery request,
                                                                                      CancellationToken cancellationToken)
  {
    // Check if the entity exists in the repository.
    var existing = await unitOfWork.Repository
                                   .AnyByIdAsync(request.Id,
                                                 cancellationToken);
    
    // Throw an exception if the TaskEntity is not found.
    if (!existing)
      throw new TaskEntityNotFoundException($"The TaskEntity woth the Id: \"{request.Id}\" wasn't found.");

    // Retrieve the TaskEntity from the repository.
    var taskEntity = await unitOfWork.Repository
                                     .FirstByIdAsync(request.Id,
                                                     cancellationToken);
    // Adapt the TaskEntity to a TaskEntityDTO.
    var result = taskEntity.Adapt<TaskEntityDTO>();
    
    // Return the adapted DTO.
    return result;
  }
}
