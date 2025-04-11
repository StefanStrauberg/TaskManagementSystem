namespace TaskService.Application.Features.Queries;

/// <summary>
/// Represents a query to retrieve all TaskEntities.
/// </summary>
public record GetTaskEntitiesQuery() : IQuery<IEnumerable<TaskEntityDTO>>;

/// <summary>
/// Handles the GetTaskEntitiesQuery by retrieving and adapting all TaskEntities to DTOs.
/// </summary>
internal class GetTaskEntitiesQueryHandler(IUnitOfWork unitOfWork)
  : IRequestHandler<GetTaskEntitiesQuery, IEnumerable<TaskEntityDTO>>
{
  /// <summary>
  /// Processes the GetTaskEntitiesQuery to retrieve all TaskEntities and adapt them to DTOs.
  /// </summary>
  /// <param name="request">The query object (no parameters).</param>
  /// <param name="cancellationToken">Token to cancel the operation if needed.</param>
  /// <returns>An enumerable of TaskEntityDTOs representing all TaskEntities.</returns>
  async Task<IEnumerable<TaskEntityDTO>> IRequestHandler<GetTaskEntitiesQuery, IEnumerable<TaskEntityDTO>>.Handle(GetTaskEntitiesQuery request,
                                                                                                                  CancellationToken cancellationToken)
  {
    // Retrieve all TaskEntities from the repository.
    var taskEntities = await unitOfWork.Repository
                                       .GetAllAsync(cancellationToken);

    // Adapt the list of TaskEntities to a list of TaskEntityDTOs.
    var result = taskEntities.Adapt<IEnumerable<TaskEntityDTO>>();

    // Return the adapted DTOs.
    return result;
  }
}