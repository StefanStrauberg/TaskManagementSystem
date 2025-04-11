namespace BuildingBlocks.Models.Exceptions;

/// <summary>
/// Exception for resource not found (HTTP 404).
/// </summary>
public abstract class NotFoundException(string message) 
  : ApplicationException("Not Found", message)
{
}
