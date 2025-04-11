namespace TaskService.Application.Features.Commands;

/// <summary>
/// Represents a command to delete a specific TaskEntity identified by its unique ID.
/// </summary>
/// <param name="Id">The unique identifier of the TaskEntity to be deleted.</param>
public record DeleteTaskEntitiesCommand(Guid Id) : ICommand;

/// <summary>
/// Handles the DeleteTaskEntitiesCommand by validating the entity's existence, 
/// retrieving it from the repository, and deleting it.
/// </summary>
internal class DeleteTaskEntitiesCommandHandler(IUnitOfWork unitOfWork)
  : ICommandHandler<DeleteTaskEntitiesCommand>
{
  /// <summary>
  /// Processes the DeleteTaskEntitiesCommand to remove a TaskEntity from the repository.
  /// </summary>
  /// <param name="request">The command containing the ID of the TaskEntity to be deleted.</param>
  /// <param name="cancellationToken">Token to cancel the operation if necessary.</param>
  /// <returns>A Unit indicating the successful completion of the command.</returns>
  async Task<Unit> IRequestHandler<DeleteTaskEntitiesCommand, Unit>.Handle(DeleteTaskEntitiesCommand request,
                                                                           CancellationToken cancellationToken)
  {
    // Validate if the TaskEntity exists in the repository using its ID.
    var existing = await unitOfWork.Repository
                                   .AnyByIdAsync(request.Id,
                                                 cancellationToken);
    
    // If the entity does not exist, throw a custom exception indicating the entity was not found.
    if (!existing)
      throw new TaskEntityNotFoundException($"The TaskEntity woth the Id: \"{request.Id}\" wasn't found.");
    
    // Retrieve the TaskEntity from the repository for deletion.
    var taskEntity = await unitOfWork.Repository
                                     .FirstByIdAsync(request.Id,
                                                     cancellationToken);
    
    // Perform the deletion of the TaskEntity.
    unitOfWork.Repository.DeleteOne(taskEntity);

    // Commit the transaction to persist the deletion in the database.
    await unitOfWork.CommitAsync(cancellationToken);
    
    // Return Unit to signal the successful execution of the command.
    return Unit.Value;
  }
}
