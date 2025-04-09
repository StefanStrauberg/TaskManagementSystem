namespace TaskService.Application.Contracts.CQRS;

/// <summary>
/// Represents a marker interface for commands without a response type.
/// Commands modify the application state without returning a result.
/// </summary>
public interface ICommand : ICommand<Unit>
{ }

/// <summary>
/// Represents a generic interface for commands that may return a response.
/// Commands perform actions and optionally return a result of type <typeparamref name="TResponse"/>.
/// </summary>
public interface ICommand<out TResponse> : IRequest<TResponse>
{ }