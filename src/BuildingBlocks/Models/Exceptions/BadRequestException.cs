namespace BuildingBlocks.Models.Exceptions;

/// <summary>
/// Exception for bad requests (HTTP 400).
/// </summary>
public abstract class BadRequestException : ApplicationException
{
  protected BadRequestException(string message)
    : base("Bad request", message)
  {}

  protected BadRequestException(string message,
                                Exception innerException)
    : base("Bad request", message, innerException)
  {}
}
