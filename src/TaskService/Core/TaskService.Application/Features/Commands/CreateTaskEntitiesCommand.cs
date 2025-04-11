namespace TaskService.Application.Features.Commands;

/// <summary>
/// Represents a command to create a new TaskEntity from its DTO representation.
/// </summary>
/// <param name="TaskEntityDTO">The DTO containing the data to create the TaskEntity.</param>
public record CreateTaskEntitiesCommand(CreateTaskEntityDTO TaskEntityDTO) : ICommand;

/// <summary>
/// Handles the CreateTaskEntitiesCommand by saving the new TaskEntity to the repository.
/// </summary>
internal class CreateTaskEntitiesCommandHandler(IUnitOfWork unitOfWork)
  : ICommandHandler<CreateTaskEntitiesCommand>
{
  /// <summary>
  /// Processes the CreateTaskEntitiesCommand to create and persist a new TaskEntity.
  /// </summary>
  /// <param name="request">The command containing the TaskEntityDTO to create the TaskEntity.</param>
  /// <param name="cancellationToken">Token to cancel the operation if needed.</param>
  /// <returns>A Unit indicating successful completion.</returns>
  async Task<Unit> IRequestHandler<CreateTaskEntitiesCommand, Unit>.Handle(CreateTaskEntitiesCommand request,
                                                                           CancellationToken cancellationToken)
  {
    // Adapt the DTO to a TaskEntity.
    var taskEntity = request.TaskEntityDTO
                            .Adapt<TaskEntity>();

    // Insert the new TaskEntity into the repository.
    unitOfWork.Repository
              .InsertOne(taskEntity);

    // Commit the transaction to persist changes.
    await unitOfWork.CommitAsync(cancellationToken);

    // Return Unit to indicate successful completion.
    return Unit.Value;
  }
}
