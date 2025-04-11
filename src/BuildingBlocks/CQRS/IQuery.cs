namespace BuildingBlocks.CQRS;

/// <summary>
/// Represents a generic interface for queries that retrieve data.
/// Queries do not modify state and return a result of type <typeparamref name="TResponse"/>.
/// </summary>
public interface IQuery<out TResponse> : IRequest<TResponse>
  where TResponse : notnull
{ }
