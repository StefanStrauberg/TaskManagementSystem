namespace TaskService.Application.Features.Commands;

/// <summary>
/// Represents a command to update an existing TaskEntity with new data provided in its DTO representation.
/// </summary>
/// <param name="TaskEntityDTO">The DTO containing updated data for the TaskEntity.</param>
public record UpdateTaskEntitiesCommand(UpdateTaskEntityDTO TaskEntityDTO) : ICommand;

/// <summary>
/// Handles the UpdateTaskEntitiesCommand by checking the existence of the TaskEntity, updating it, and persisting changes.
/// </summary>
internal class UpdateTaskEntitiesCommandHandler(IUnitOfWork unitOfWork)
  : ICommandHandler<UpdateTaskEntitiesCommand>
{
  /// <summary>
  /// Processes the UpdateTaskEntitiesCommand to update an existing TaskEntity with new data.
  /// </summary>
  /// <param name="request">The command containing the UpdateTaskEntityDTO with updated data.</param>
  /// <param name="cancellationToken">Token to cancel the operation if needed.</param>
  /// <returns>A Unit indicating successful completion.</returns>
  async Task<Unit> IRequestHandler<UpdateTaskEntitiesCommand, Unit>.Handle(UpdateTaskEntitiesCommand request,
                                                                           CancellationToken cancellationToken)
  {
    // Validate if the TaskEntity exists in the repository using its ID.
    var existing = await unitOfWork.Repository
                                   .AnyByIdAsync(request.TaskEntityDTO.Id,
                                                 cancellationToken);
    
    // If the entity does not exist, throw a custom exception indicating the entity was not found.
    if (!existing)
      throw new TaskEntityNotFoundException($"The TaskEntity woth the Id: \"{request.TaskEntityDTO.Id}\" wasn't found.");

    // Map the DTO to a TaskEntity object for updating the database.
    var taskEntity = request.TaskEntityDTO
                            .Adapt<TaskEntity>();

    // Replace the existing TaskEntity in the repository with the updated version.
    unitOfWork.Repository
              .ReplaceOne(taskEntity);

    // Commit the transaction to persist changes in the database.
    await unitOfWork.CommitAsync(cancellationToken);

    // Return Unit to indicate successful completion of the command.
    return Unit.Value;
  }
}