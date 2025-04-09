namespace TaskService.Application.Contracts.CQRS;

/// <summary>
/// Represents a handler interface for commands without a response.
/// Implements the IRequestHandler interface for commands that modify state but do not return a result.
/// </summary>
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit> 
  where TCommand : ICommand<Unit>
{ }

/// <summary>
/// Represents a generic handler interface for commands that return a response.
/// Implements the IRequestHandler interface for commands that modify state and return a result.
/// </summary>
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
  where TCommand : ICommand<TResponse>
{ }