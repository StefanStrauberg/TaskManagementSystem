namespace TaskService.Application.Contracts.CQRS;

/// <summary>
/// Represents a handler interface for queries.
/// Queries are processed and return a result without modifying state.
/// Implements the IRequestHandler interface for handling queries.
/// </summary>
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
  where TQuery : IRequest<TResponse>
{ }
